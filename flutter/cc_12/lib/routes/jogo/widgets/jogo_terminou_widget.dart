import 'package:cc04/functions/getit_function.dart';
import 'package:cc04/routes/jogo/mobx_stores/jogo_store.dart';
import 'package:flutter/material.dart';

class JogoTerminouWidget extends StatelessWidget {
  final String urlImagem;
  final String mensagem;

  const JogoTerminouWidget({this.urlImagem, this.mensagem});

  @override
  Widget build(BuildContext context) {
    Future.delayed(Duration(seconds: 5)).then((_) {
      getIt.get<JogoStore>().ganhou = false;
      getIt.get<JogoStore>().perdeu = false;
      getIt.get<JogoStore>().palavraAdivinhadaFormatada = '';
      getIt.get<JogoStore>().animacaoFlare = 'idle';
      getIt.get<JogoStore>().quantidadeErros = 0;
    });

    return Stack(
      children: <Widget>[
        Container(
          decoration: BoxDecoration(
            image: DecorationImage(
                image: AssetImage(urlImagem), fit: BoxFit.cover),
          ),
        ),
        Align(
          alignment: Alignment.bottomCenter,
          child: Padding(
            padding: const EdgeInsets.all(8.0),
            child: Container(
              height: 100,
              decoration: BoxDecoration(
                  color: Colors.green,
                  borderRadius: BorderRadius.all(Radius.circular(5)),
                  boxShadow: [
                    BoxShadow(
                      blurRadius: 5,
                      color: Colors.white,
                      spreadRadius: 5,
                      offset: Offset(0.1, 0.1),
                    )
                  ]),
              child: Center(
                child: Text(
                  mensagem,
                  textAlign: TextAlign.center,
                  style: TextStyle(fontSize: 30),
                ),
              ),
            ),
          ),
        )
      ],
    );
  }
}
