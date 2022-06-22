import 'package:flutter/material.dart';

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
              ListTile(
                contentPadding: const EdgeInsets.only(left: 62.0),
                trailing: const Icon(Icons.arrow_forward),
                title: const Text('Novas Palavras'),
                subtitle: const Text('Vamos inserir palavras?'),
                onTap: () {},
              ),
              ListTile(
                contentPadding: const EdgeInsets.only(left: 62.0),
                trailing: const Icon(Icons.arrow_forward),
                title: const Text('Palavras existentes'),
                subtitle: const Text('Vamos ver as que já temos?'),
                onTap: () {},
              ),
            ],
          ),
        ),
        ListTile(
          contentPadding: const EdgeInsets.only(left: 6.0),
          leading: const CircleAvatar(
            backgroundImage: AssetImage('assets/images/drawer/jogar.png'),
          ),
          trailing: const Icon(Icons.arrow_forward),
          title: const Text('Jogar'),
          subtitle: const Text('Começar a diversão'),
          onTap: () {},
        ),
        ListTile(
          contentPadding: const EdgeInsets.only(left: 6.0),
          leading: const CircleAvatar(
            backgroundImage: AssetImage('assets/images/drawer/top10.png'),
          ),
          trailing: const Icon(Icons.arrow_forward),
          title: const Text('Score'),
          subtitle: const Text('Relação dos top 10'),
          onTap: () {},
        ),
      ],
    );
  }
}
