import 'package:cc04/shared_preferences/app_preferences.dart';
import 'package:flutter/material.dart';
import 'package:cc04/drawer/drawer_route.dart';

class WelcomeRoute extends StatefulWidget {
  @override
  _WelcomeRouteState createState() => _WelcomeRouteState();
}

class _WelcomeRouteState extends State<WelcomeRoute> {
  bool _checkBoxIsChecked = false;

  @override
  void initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        width: double.infinity,
        child: Stack(
          children: <Widget>[
            Align(
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
                    Text(
                      'Marcar como lido',
                      style: TextStyle(
                        fontSize: 20,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                    SizedBox(
                      width: 5,
                    ),
                    Checkbox(
                      value: this._checkBoxIsChecked,
                      onChanged: (status) {
                        setState(() {
                          this._checkBoxIsChecked = status;
                        });
                      },
                    ),
                  ],
                ),
                SizedBox(
                  width: 10,
                ),
                RaisedButton(
                  onPressed: () async {
                    AppPreferences.setWelcomeRead(
                        status: this._checkBoxIsChecked);

                    Navigator.push(
                      context,
                      MaterialPageRoute(builder: (context) => DrawerRoute()),
                    );
                  },
                  child: Text('Avançar', style: TextStyle(fontSize: 20)),
                )
              ],
            ),
          ],
        ),
      ),
    );
  }
}
