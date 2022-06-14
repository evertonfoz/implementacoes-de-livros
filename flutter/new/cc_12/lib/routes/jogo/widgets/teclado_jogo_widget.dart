import 'package:capitulo03_splashscreen/functions/getit_function.dart';
import 'package:capitulo03_splashscreen/routes/jogo/mobx_stores/jogo_store.dart';
import 'package:capitulo03_splashscreen/routes/jogo/mobx_stores/teclado_store.dart';
import 'package:flutter/material.dart';
import 'package:flutter_mobx/flutter_mobx.dart';

class TecladoJogoWidget extends StatefulWidget {
  const TecladoJogoWidget({Key? key}) : super(key: key);

  @override
  _TecladoJogoWidgetState createState() => _TecladoJogoWidgetState();
}

class _TecladoJogoWidgetState extends State<TecladoJogoWidget> {
  final String letrasParaTeclado = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
  final TecladoStore _tecladoStore = TecladoStore();
  late JogoStore _jogoStore;
  // final List<Widget> textsParaLetras = [];

  @override
  void initState() {
    super.initState();
    _tecladoStore.inicializarTeclado(letrasParaTeclado: letrasParaTeclado);
    _jogoStore = getIt.get<JogoStore>();
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

  List<Widget> _gerarTeclado() {
    List<Widget> teclado = [];
    for (int i = 0; i < _tecladoStore.widgetsDeLetrasDoTeclado.length; i++) {
      teclado.add(Observer(builder: (context) {
        return InkWell(
          onTap: _tecladoStore.widgetsDeLetrasDoTeclado[i].foiUtilizada
              ? null
              : () {
                  if (_jogoStore.animacaoFlare == 'enforcamento') return;

                  _tecladoStore.letraPressionada(indiceDaLetra: i);
                  _jogoStore.verificarExistenciaDaLetraNaPalavraParaAdivinhar(
                      letra: _tecladoStore.widgetsDeLetrasDoTeclado[i].letra);
                },
          child: Observer(builder: (context) {
            return _tecladoStore.widgetsDeLetrasDoTeclado[i];
          }),
        );
      }));
    }
    return teclado;
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
}
