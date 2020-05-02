import 'package:cc04/functions/getit_function.dart';
import 'package:cc04/routes/jogo/mixins/jogo_mixin.dart';
import 'package:flutter/material.dart';
import 'package:flutter_mobx/flutter_mobx.dart';

import 'mobx_stores/jogo_store.dart';
import 'mobx_stores/teclado_store.dart';
import 'widgets/letra_teclado_jogo_widget.dart';

class JogoRoute extends StatefulWidget {
  @override
  _JogoRouteState createState() => _JogoRouteState();
}

class _JogoRouteState extends State<JogoRoute> with JogoMixin {
  JogoStore _jogoStore;

//  List<ReactionDisposer> _reactionDisposers;
//  bool _jogoIniciado = false;
//  String _ajudaParaPalavra = '';

  @override
  void initState() {
    super.initState();
    _jogoStore = getIt.get<JogoStore>();

    for (int i = 0; i < letrasParaTeclado.length; i++) {
      widgetsDeLetrasDoTeclado.add(
        LetraTecladoJogoWidget(
          letra: this.letrasParaTeclado[i],
        ),
      );
    }
  }

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
//    _reactionDisposers ??= [
//      reaction(
//        (_) => _jogoStore.palavraParaAdivinhar,
//        (String palavra) => print('nova palavra: $palavra'),
//      ),
//      reaction(
//        (_) => _jogoStore.ajudaPalavraParaAdivinhar,
//        (String ajuda) {
//          print('nova ajuda: $ajuda');
//          setState(() {
//            this._jogoIniciado = !this._jogoIniciado;
//            this._ajudaParaPalavra = ajuda;
//          });
//        },
//      ),
//    ];
  }

  @override
  void dispose() {
//    _reactionDisposers.forEach((d) => d());
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
        child: Observer(
          builder: (_) {
            return Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: <Widget>[
                titulo(),
                botaoParaSorteioDePalavra(
                  onPressed: () =>
                      this._jogoStore.selecionarPalavraParaAdivinhar(),
                ),
                palavraParaAdivinhar(
                    palavra: this._jogoStore.palavraAdivinhadaFormatada),
                ajudaParaAdivinharAPalavra(
                    ajuda: this._jogoStore.ajudaPalavraParaAdivinhar),
                animacaoDaForca(animacao: 'idle'),
                exibirTecladoParaJogo(letras: this.widgetsDeLetrasDoTeclado),
              ],
            );
          },
        ),
      ),
    );
  }
}
