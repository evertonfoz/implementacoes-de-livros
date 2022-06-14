import 'package:flutter/material.dart';

import '../shared_preferences/app_preferences.dart';
import 'home_route.dart';

class WelcomeRoute extends StatefulWidget {
  const WelcomeRoute({Key? key}) : super(key: key);

  @override
  _WelcomeRouteState createState() => _WelcomeRouteState();
}

class _WelcomeRouteState extends State<WelcomeRoute> {
  bool _checkBoxIsChecked = false;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SizedBox(
        width: double.maxFinite,
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
                          builder: (context) => const HomeRoute()),
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
