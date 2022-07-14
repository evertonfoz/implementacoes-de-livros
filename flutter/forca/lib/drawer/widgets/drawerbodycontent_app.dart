import 'package:flutter/material.dart';
import 'package:forca/app_constants/router_constants.dart';
import 'package:forca/local_persistence/daos/palavra_dao.dart';
import 'package:forca/local_persistence/lp_constants.dart';
import 'package:forca/widgets/listtile_app_widget.dart';
import 'package:giff_dialog/giff_dialog.dart';

class DrawerBodyContentApp extends StatelessWidget {
  const DrawerBodyContentApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return ListView(
      children: <Widget>[
        ListTileTheme(
          contentPadding: const EdgeInsets.only(left: 6.0),
          child: ExpansionTile(
            leading: const CircleAvatar(
              backgroundImage:
                  AssetImage('assets/images/drawer/base_de_palavras.png'),
            ),
            title: const Text(
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
          contentPadding: const EdgeInsets.only(left: 6.0),
          titleText: 'Jogar',
          subtitleText: 'Começar a diversão',
          avatarImage: const AssetImage('assets/images/drawer/jogar.png'),
          onTap: () async {
            try {
              PalavraDAO palavraDAO = PalavraDAO();
              final List data = await palavraDAO.getAll();
              if (data.isEmpty) {
                await showDialog(
                  context: context,
                  builder: (_) => AssetGiffDialog(
                    image: Image.asset(
                      "assets/gifs/error.gif",
                      fit: BoxFit.cover,
                    ),
                    title: const Text(
                      'Não existem palavras registradas',
                      textAlign: TextAlign.center,
                      style: TextStyle(
                          fontSize: 22.0, fontWeight: FontWeight.w600),
                    ),
                    description: const Text(
                      'Para você poder jogar a forca, você precisa antes registrar algumas palavras',
                      textAlign: TextAlign.center,
                    ),
                    buttonOkText:
                        const Text('Ok', style: TextStyle(color: Colors.white)),
                    onlyOkButton: true,
                    entryAnimation: EntryAnimation.bottomRight,
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
          contentPadding: const EdgeInsets.only(left: 6.0),
          titleText: 'Score',
          subtitleText: 'Relação dos top 10',
          avatarImage: const AssetImage('assets/images/drawer/top10.png'),
          onTap: () {},
        ),
      ],
    );
  }

  ListTile _createListTile({
    required EdgeInsets contentPadding,
    ImageProvider? avatarImage,
    required String titleText,
    required String subtitleText,
    required VoidCallback? onTap,
  }) {
    return ListTile(
      contentPadding: contentPadding,
      leading: avatarImage != null
          ? CircleAvatar(backgroundImage: avatarImage)
          : null,
      trailing: const Icon(Icons.arrow_forward),
      title: Text(titleText),
      subtitle: Text(subtitleText),
      onTap: onTap,
    );
  }
}
