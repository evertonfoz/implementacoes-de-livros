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

  @override
  void initState() {
    super.initState();
    _tecladoStore = TecladoStore();
    _tecladoStore.inicializarTeclado(letrasParaTeclado: letrasParaTeclado);
  }

  @override
  Widget build(BuildContext context) {
    return Wrap(
      alignment: WrapAlignment.center,
      spacing: 20,
      runSpacing: 5,
      children: widget.textsParaLetras,
    );
  }

  _gerarTeclado(teste) {
    var teclado = List<Widget>();
    for (int i = 0; i < _tecladoStore.widgetsDeLetrasDoTeclado.length; i++) {
      teclado.add(InkWell(
        onTap: () {
          print('Letra Pressionada');
        },
        child: _tecladoStore.widgetsDeLetrasDoTeclado[i],
      ));
    }
    return teclado;
  }
}
