import 'package:flutter/material.dart';

class WelcomeRoute extends StatefulWidget {
  @override
  _WelcomeRouteState createState() => _WelcomeRouteState();
}

class _WelcomeRouteState extends State<WelcomeRoute> {
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
                      value: true,
                    ),
                  ],
                ),
                SizedBox(
                  width: 10,
                ),
                const RaisedButton(
                  onPressed: null,
                  child:
                      Text('Disabled Button', style: TextStyle(fontSize: 20)),
                )
              ],
            ),
          ],
        ),
      ),
    );
  }
}
