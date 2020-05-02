import 'package:cc04/functions/getit_function.dart';
import 'package:cc04/routes/jogo/mobx_stores/jogo_store.dart';
import 'package:cc04/routes/jogo/mobx_stores/teclado_store.dart';
import 'package:flutter/material.dart';

class TecladoJogoWidget extends StatefulWidget {
  final List<Widget> textsParaLetras;

  const TecladoJogoWidget({this.textsParaLetras});

  @override
  _TecladoJogoWidgetState createState() => _TecladoJogoWidgetState();
}

class _TecladoJogoWidgetState extends State<TecladoJogoWidget> {
  String letrasParaTeclado = 'ABCDEFGHIJKLMNOPQRSTUWXYZ';
  TecladoStore _tecladoStore;
  JogoStore _jogoStore;

  @override
  void initState() {
    super.initState();
    _tecladoStore = TecladoStore();
    _jogoStore = getIt.get<JogoStore>();
    _tecladoStore.inicializarTeclado(letrasParaTeclado: letrasParaTeclado);
  }

  @override
  Widget build(BuildContext context) {
    return Wrap(
      alignment: WrapAlignment.center,
      spacing: 20,
      runSpacing: 5,
      children: _gerarTeclado(_tecladoStore.widgetsDeLetrasDoTeclado),
    );
  }

  _gerarTeclado(teste) {
    var teclado = List<Widget>();
    for (int i = 0; i < _tecladoStore.widgetsDeLetrasDoTeclado.length; i++) {
      teclado.add(
        InkWell(
          onTap: (!_tecladoStore.widgetsDeLetrasDoTeclado[i].foiUtilizada)
              ? () {
                  _tecladoStore.letraPressionada(indiceDaLetra: i);
                  _jogoStore.verificarExistenciaDaLetraNaPalavraParaAdivinhar(
                      letra: _tecladoStore.widgetsDeLetrasDoTeclado[i].letra);
                }
              : null,
          child: _tecladoStore.widgetsDeLetrasDoTeclado[i],
        ),
      );
    }
    return teclado;
  }
}
