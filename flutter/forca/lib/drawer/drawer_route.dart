import 'package:flutter/material.dart';

class DrawerRoute extends StatelessWidget {
  const DrawerRoute({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text(
          "Jogo da Forca",
        ),
        centerTitle: true,
      ),
      body: Container(),
      drawer: const Drawer(),
    );
  }
}
