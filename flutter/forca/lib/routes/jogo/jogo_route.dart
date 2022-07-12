import 'package:flare_flutter/flare_actor.dart';
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
            _palavraParaAdivinhar(palavra: '_ _ _ _ _ _ _ _ _ _'),
            _animacaoDaForca(animacao: 'idle'),
            _letrasParaSelecao(letras: 'ABCDEFGHIJKLMNOPQRSTUWXYZ'),
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

  _palavraParaAdivinhar({required String palavra}) {
    return Padding(
      padding: const EdgeInsets.only(top: 20.0, bottom: 10),
      child: Text(
        palavra,
        style: const TextStyle(
          fontSize: 30,
        ),
      ),
    );
  }

  _animacaoDaForca({required String animacao}) {
    return Expanded(
      child: FlareActor(
        "assets/flare/forca_casa_do_codigo.flr",
        alignment: Alignment.center,
        fit: BoxFit.contain,
        animation: animacao,
      ),
    );
  }

  _letrasParaSelecao({required String letras}) {
    List<Widget> textsParaLetras = [];

    for (int i = 0; i < letras.length; i++) {
      textsParaLetras.add(Text(
        letras[i],
        style: const TextStyle(
          fontSize: 40,
        ),
      ));
    }

    return Padding(
      padding: const EdgeInsets.only(left: 10, right: 10, bottom: 10.0),
      child: Wrap(
        alignment: WrapAlignment.center,
        spacing: 20,
        runSpacing: 5,
        children: textsParaLetras,
      ),
    );
  }
}
