import 'package:flutter/material.dart';

class JogoRoute extends StatefulWidget {
  @override
  _JogoRouteState createState() => _JogoRouteState();
}

class _JogoRouteState extends State<JogoRoute> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            _titulo(),
            _botaoParaSorteioDePalavra(),
            const Placeholder(fallbackHeight: 100, color: Colors.green),
            const Placeholder(fallbackHeight: 350, color: Colors.yellow),
            const Placeholder(fallbackHeight: 100, color: Colors.black),
          ],
        ),
      ),
    );
  }

  _titulo() {
    return const Padding(
      padding: EdgeInsets.only(top: 10.0, bottom: 15),
      child: Text(
        'Vamos jogar a Forca?',
        style: TextStyle(
          fontSize: 30,
        ),
      ),
    );
  }

  _botaoParaSorteioDePalavra() {
    return Container(
      padding: const EdgeInsets.only(bottom: 5.0),
      height: 50,
      decoration: const BoxDecoration(
        boxShadow: [
          BoxShadow(
            color: Colors.indigo,
            blurRadius: 20.0,
            spreadRadius: 1.0,
            offset: Offset(
              5.0,
              5.0,
            ),
          )
        ],
      ),
      child: TextButton(
        style: ButtonStyle(
          foregroundColor: MaterialStateProperty.all(
            Colors.black,
          ),
          backgroundColor: MaterialStateProperty.all(
            Colors.blue[200],
          ),
        ),
        onPressed: () {},
        child: const Text('Pressione para sortear uma palavra'),
      ),
    );
  }
}
