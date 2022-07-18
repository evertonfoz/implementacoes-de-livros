import 'package:flutter/material.dart';
import 'package:flutter_mobx/flutter_mobx.dart';
import 'package:forca/functions/getit_function.dart';
import 'package:forca/routes/jogo/mobx_stores/jogo_store.dart';
import 'package:forca/routes/jogo/mobx_stores/teclado_store.dart';

import 'letra_teclado_jogo_widget.dart';

class TecladoJogoWidget extends StatefulWidget {
  const TecladoJogoWidget({Key? key}) : super(key: key);

  @override
  _TecladoJogoWidgetState createState() => _TecladoJogoWidgetState();
}

class _TecladoJogoWidgetState extends State<TecladoJogoWidget> {
  final TecladoStore _tecladoStore = TecladoStore();
  final String letrasParaTeclado = 'ABCDEFGHIJKLMNOPQRSTVUWXYZ0123456789';
  final List<Widget> textsParaLetras = [];
  late JogoStore _jogoStore;

  @override
  void initState() {
    super.initState();
    _jogoStore = getIt.get<JogoStore>();
    _tecladoStore.inicializarTeclado(letrasParaTeclado: letrasParaTeclado);

    // for (int i = 0; i < letrasParaTeclado.length; i++) {
    //   textsParaLetras.add(
    //     InkWell(
    //       child: LetraTecladoJogoWidget(
    //         letra: letrasParaTeclado[i],
    //       ),
    //       onTap: () => print('Letra ${letrasParaTeclado[i]} foi pressionada'),
    //     ),
    //   );
    // }
  }

  @override
  Widget build(BuildContext context) {
    return Wrap(
      alignment: WrapAlignment.center,
      spacing: 20,
      runSpacing: 5,
      children: _gerarTeclado(),
    );
  }

  List<Widget> _gerarTeclado() {
    List<Widget> teclado = [];
    for (int i = 0; i < _tecladoStore.widgetsDeLetrasDoTeclado.length; i++) {
      teclado.add(
        Observer(
          builder: (context) {
            return InkWell(
              onTap: _tecladoStore.widgetsDeLetrasDoTeclado[i].foiUtilizada
                  ? null
                  : () {
                      if (_jogoStore.animacaoFlare == 'enforcamento') return;
                      _tecladoStore.letraPressionada(indiceDaLetra: i);
                      _jogoStore
                          .verificarExistenciaDaLetraNaPalavraParaAdivinhar(
                              letra: _tecladoStore
                                  .widgetsDeLetrasDoTeclado[i].letra);
                    },
              child: Observer(builder: (context) {
                return _tecladoStore.widgetsDeLetrasDoTeclado[i];
              }),
            );
          },
        ),
      );
    }
    return teclado;
  }
}
