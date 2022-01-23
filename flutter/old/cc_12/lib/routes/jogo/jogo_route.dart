import 'package:cc04/functions/getit_function.dart';
import 'package:cc04/routes/jogo/mixins/jogo_mixin.dart';
import 'package:flutter/material.dart';
import 'package:flutter_mobx/flutter_mobx.dart';

import 'mobx_stores/jogo_store.dart';
import 'widgets/jogo_terminou_widget.dart';
import 'widgets/teclado_jogo_widget.dart';

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
            if (this._jogoStore.ganhou) {
              return JogoTerminouWidget(
                urlImagem: "assets/images/jogo/vitoria.jpg",
                mensagem: 'Parabéns pela vitória. Já retornaremos ao jogo.',
              );
            } else if (this._jogoStore.perdeu) {
              return JogoTerminouWidget(
                urlImagem: "assets/images/jogo/derrota.jpg",
                mensagem: 'Que pena, você perdeu, mas já retornaremos ao jogo.',
              );
            }
            return Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: <Widget>[
                Visibility(
                  visible: this._jogoStore.palavraAdivinhadaFormatada.isEmpty,
                  child: titulo(),
                ),
                Visibility(
                  visible: this._jogoStore.palavraAdivinhadaFormatada.isEmpty,
                  child: botaoParaSorteioDePalavra(
                    onPressed: () =>
                        this._jogoStore.selecionarPalavraParaAdivinhar(),
                  ),
                ),
                Visibility(
                  visible:
                      this._jogoStore.palavraAdivinhadaFormatada.isNotEmpty,
                  child: palavraParaAdivinhar(
                      palavra: this._jogoStore.palavraAdivinhadaFormatada),
                ),
                Visibility(
                  visible:
                      this._jogoStore.palavraAdivinhadaFormatada.isNotEmpty,
                  child: ajudaParaAdivinharAPalavra(
                      ajuda: this._jogoStore.ajudaPalavraParaAdivinhar),
                ),
                animacaoDaForca(animacao: this._jogoStore.animacaoFlare),
                Visibility(
                  visible:
                      this._jogoStore.palavraAdivinhadaFormatada.isNotEmpty,
                  child: TecladoJogoWidget(),
                ),
              ],
            );
          },
        ),
      ),
      floatingActionButton: Observer(builder: (_) {
        return Visibility(
          visible: this._jogoStore.palavraAdivinhadaFormatada.isEmpty,
          child: FloatingActionButton(
            onPressed: () => Navigator.of(context).pop(),
            child: Icon(Icons.arrow_back),
          ),
        );
      }),
    );
  }
}
