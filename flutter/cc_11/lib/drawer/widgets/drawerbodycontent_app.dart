import 'package:cc04/app_constants/router_constants.dart';
import 'package:cc04/local_persistence/daos/palavra_dao.dart';
import 'package:flutter/material.dart';
import 'package:giffy_dialog/giffy_dialog.dart';

import 'listtile_app_widget.dart';

class DrawerBodyContentApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return ListView(
      children: <Widget>[
        ListTileTheme(
          contentPadding: EdgeInsets.only(left: 6.0),
          child: ExpansionTile(
            leading: CircleAvatar(
              backgroundImage:
                  AssetImage('assets/images/drawer/base_de_palavras.png'),
            ),
            title: Text(
              "Base de Palavras",
              style: TextStyle(
                color: Colors.black,
                fontSize: 16.0,
              ),
            ),
            onExpansionChanged: null,
            children: <Widget>[
              ListTileAppWidget(
                titleText: 'Novas Palavras',
                subtitleText: 'Vamos inserir palavras?',
                onTap: () {
                  Navigator.of(context).pop();
                  Navigator.of(context).pushNamed(kPalavrasCRUDRoute);
                },
              ),
              ListTileAppWidget(
                titleText: 'Palavras existentes',
                subtitleText: 'Vamos ver as que já temos?',
                onTap: () {
                  Navigator.of(context).pop();
                  Navigator.of(context).pushNamed(kPalavrasAllRoute);
                },
              ),
            ],
          ),
        ),
        _createListTile(
          contentPadding: EdgeInsets.only(left: 6.0),
          titleText: 'Jogar',
          subtitleText: 'Começar a diversão',
          avatarImage: AssetImage('assets/images/drawer/jogar.png'),
          onTap: () async {
            try {
              PalavraDAO palavraDAO = PalavraDAO();
              final List data = await palavraDAO.getAll();
              if (data.length == 0) {
                await showDialog(
                  context: context,
                  builder: (_) => AssetGiffyDialog(
                    image: Image.asset(
                      "assets/gifs/error.gif",
                      fit: BoxFit.cover,
                    ),
                    title: Text(
                      'Não existem palavras registradas',
                      textAlign: TextAlign.center,
                      style: TextStyle(
                          fontSize: 22.0, fontWeight: FontWeight.w600),
                    ),
                    description: Text(
                      'Para você poder jogar a forca, você precisa antes registrar algumas palavras',
                      textAlign: TextAlign.center,
                    ),
                    buttonOkText: Text('Ok'),
                    onlyOkButton: true,
                    entryAnimation: EntryAnimation.BOTTOM_RIGHT,
                    onOkButtonPressed: () => Navigator.of(context).pop(),
                  ),
                );
              } else {
                Navigator.of(context).pop();
                Navigator.of(context).pushNamed(kJogoRoute);
              }
            } catch (exception) {
              rethrow;
            }
          },
        ),
        _createListTile(
          contentPadding: EdgeInsets.only(left: 6.0),
          titleText: 'Score',
          subtitleText: 'Relação dos top 10',
          avatarImage: AssetImage('assets/images/drawer/top10.png'),
        ),
      ],
    );
  }

  ListTile _createListTile(
      {@required EdgeInsets contentPadding,
      ImageProvider avatarImage,
      @required String titleText,
      @required String subtitleText,
      @required Function onTap}) {
    return ListTile(
      contentPadding: contentPadding,
      leading: avatarImage != null
          ? CircleAvatar(backgroundImage: avatarImage)
          : null,
      trailing: Icon(Icons.arrow_forward),
      title: Text(titleText),
      subtitle: Text(subtitleText),
      onTap: onTap,
    );
  }
}
