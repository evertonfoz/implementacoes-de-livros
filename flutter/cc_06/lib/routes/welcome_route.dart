import 'package:flutter/material.dart';
import 'package:forca/drawer/drawer_route.dart';
import 'package:forca/shared_preferences/app_preferences.dart';

class WelcomeRoute extends StatefulWidget {
  const WelcomeRoute({super.key});

  @override
  // ignore: library_private_types_in_public_api
  _WelcomeRouteState createState() => _WelcomeRouteState();
}

class _WelcomeRouteState extends State<WelcomeRoute> {
  bool _checkBoxIsChecked = false;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SizedBox(
        width: double.infinity,
        child: Stack(
          children: <Widget>[
            const Align(
              alignment: Alignment.center,
              child: Text(
                'Bem-vindo',
                style: TextStyle(
                  fontSize: 40,
                  fontWeight: FontWeight.bold,
                ),
              ),
            ),
            Column(
              mainAxisAlignment: MainAxisAlignment.end,
              children: <Widget>[
                Row(
                  mainAxisAlignment: MainAxisAlignment.end,
                  children: <Widget>[
                    const Text(
                      'Marcar como lido',
                      style: TextStyle(
                        fontSize: 20,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                    const SizedBox(
                      width: 5,
                    ),
                    Checkbox(
                      value: _checkBoxIsChecked,
                      onChanged: (status) {
                        setState(() {
                          _checkBoxIsChecked = status ?? false;
                        });
                      },
                    ),
                  ],
                ),
                const SizedBox(
                  width: 10,
                ),
                ElevatedButton(
                  onPressed: () async {
                    await AppPreferences.setWelcomeRead(
                        status: _checkBoxIsChecked);

                    Navigator.push(
                      context,
                      MaterialPageRoute(
                          builder: (context) => const DrawerRoute()),
                    );
                  },
                  child: const Text('Começar', style: TextStyle(fontSize: 20)),
                )
              ],
            ),
          ],
        ),
      ),
    );
  }
}
