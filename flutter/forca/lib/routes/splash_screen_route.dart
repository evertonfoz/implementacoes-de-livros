import 'dart:async';

import 'package:flutter/material.dart';
import 'package:forca/drawer/drawer_route.dart';
import 'package:forca/shared_preferences/app_preferences.dart';
import '../widgets/circular_image_widget.dart';
import 'home_route.dart';
import 'welcome_route.dart';

class SplashScreenRoute extends StatefulWidget {
  const SplashScreenRoute({super.key});

  @override
  _SplashScreenRouteState createState() => _SplashScreenRouteState();
}

class _SplashScreenRouteState extends State<SplashScreenRoute> {
  @override
  void initState() {
    super.initState();
    Timer(const Duration(seconds: 3), () {
      WidgetsBinding.instance.addPostFrameCallback((_) {
        AppPreferences.getWelcomeRead().then((status) async {
          await _whereToNavigate(welcomeRead: status);
        });
      });
    });
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      mainAxisAlignment: MainAxisAlignment.center,
      children: <Widget>[
        const CircularImageWidget(
          imageProvider: AssetImage(
            'assets/images/splashscreen.png',
          ),
        ),
        const Padding(
          padding: EdgeInsets.only(top: 25.0, bottom: 25),
          child: Text(
            'Aguarde....',
            style: TextStyle(
              fontSize: 40,
              fontWeight: FontWeight.bold,
            ),
          ),
        ),
        Padding(
          padding: const EdgeInsets.only(left: 100, right: 100),
          child: LinearProgressIndicator(
            backgroundColor: Colors.blue[200],
            valueColor: AlwaysStoppedAnimation<Color?>(Colors.blue[900]),
          ),
        ),
      ],
    );
  }

  _whereToNavigate({required bool welcomeRead}) {
    if (welcomeRead) {
      Navigator.push(context,
          MaterialPageRoute(builder: (context) => const DrawerRoute()));
    } else {
      Navigator.push(
        context,
        MaterialPageRoute(builder: (context) => const WelcomeRoute()),
      );
    }
  }
}
