import 'package:flutter/material.dart';
import 'package:forca/functions/getit_function.dart';
import 'package:forca/routes/jogo/mobx_stores/jogo_store.dart';

class VitoriaWidget extends StatelessWidget {
  const VitoriaWidget({Key? key}) : super(key: key);
  @override
  Widget build(BuildContext context) {
    Future.delayed(const Duration(seconds: 5)).then((_) {
      getIt.get<JogoStore>().ganhou = false;
      getIt.get<JogoStore>().palavraAdivinhadaFormatada = '';
      getIt.get<JogoStore>().animacaoFlare = 'idle';
      getIt.get<JogoStore>().quantidadeErros = 0;
    });

    return Stack(
      children: <Widget>[
        Container(
          decoration: const BoxDecoration(
            image: DecorationImage(
                image: AssetImage("assets/images/jogo/vitoria.jpg"),
                fit: BoxFit.cover),
          ),
        ),
        Align(
          alignment: Alignment.bottomCenter,
          child: Padding(
            padding: const EdgeInsets.all(8.0),
            child: Container(
              height: 100,
              decoration: const BoxDecoration(
                  color: Colors.green,
                  borderRadius: const BorderRadius.all(Radius.circular(5)),
                  boxShadow: [
                    BoxShadow(
                      blurRadius: 5,
                      color: Colors.white,
                      spreadRadius: 5,
                      offset: Offset(0.1, 0.1),
                    )
                  ]),
              child: const Center(
                child: Text(
                  'Parabéns pela vitória. Já retornaremos ao jogo.',
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
