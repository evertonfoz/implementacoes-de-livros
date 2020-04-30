import 'package:cc04/routes/jogo/mixins/jogo_mixin.dart';
import 'package:flutter/material.dart';

class JogoRoute extends StatefulWidget {
  @override
  _JogoRouteState createState() => _JogoRouteState();
}

class _JogoRouteState extends State<JogoRoute> with JogoMixin {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            titulo(),
            botaoParaSorteioDePalavra(),
            palavraParaAdivinhar(palavra: '_ _ _ _ _ _ _ _ _ _'),
            animacaoDaForca(animacao: 'idle'),
            letrasParaSeleccao(letras: 'ABCDEFGHIJKLMNOPQRSTUWXYZ'),
          ],
        ),
      ),
    );
  }
}
