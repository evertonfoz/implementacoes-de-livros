import 'package:flare_flutter/flare_actor.dart';
import 'package:flare_flutter/flare_cache_builder.dart';
import 'package:flare_flutter/provider/asset_flare.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:flutter_mobx/flutter_mobx.dart';
import 'package:forca/functions/getit_function.dart';
import 'package:mobx/mobx.dart';

import 'mobx_stores/jogo_store.dart';
import 'widgets/teclado_jogo_widget.dart';
import 'widgets/jogo_terminou_widget.dart';

class JogoRoute extends StatefulWidget {
  @override
  _JogoRouteState createState() => _JogoRouteState();
}

class _JogoRouteState extends State<JogoRoute> {
  late JogoStore _jogoStore;
  List<ReactionDisposer>? _reactionDisposers;
  bool _jogoIniciado = false;
  String _ajudaParaPalavra = '';

  @override
  void initState() {
    super.initState();
    _jogoStore = getIt.get<JogoStore>();
  }

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    _reactionDisposers ??= [
      reaction<String?>(
        (_) => _jogoStore.palavraParaAdivinhar,
        (String? palavra) => print('nova palavra: $palavra'),
      ),
      reaction<String?>(
        (_) => _jogoStore.ajudaPalavraParaAdivinhar,
        (String? ajuda) {
          print('nova ajuda: $ajuda');
          setState(() {
            _jogoIniciado = !_jogoIniciado;
            _ajudaParaPalavra = ajuda!;
          });
        },
      ),
    ];
  }

  @override
  void dispose() {
    _reactionDisposers?.forEach((d) => d());
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
        child: Observer(builder: (context) {
          if (_jogoStore.ganhou) {
            return const JogoTerminouWidget(
              urlImagem: "assets/images/jogo/vitoria.jpg",
              mensagem: 'Parabéns pela vitória. Já retornaremos ao jogo.',
            );
          } else if (_jogoStore.perdeu) {
            return const JogoTerminouWidget(
              urlImagem: "assets/images/jogo/derrota.jpg",
              mensagem: 'Que pena, você perdeu, mas já retornaremos ao jogo.',
            );
          }

          return Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: <Widget>[
              Visibility(
                visible: _jogoStore.palavraAdivinhadaFormatada.isEmpty,
                child: _titulo(),
              ),
              Visibility(
                visible: _jogoStore.palavraAdivinhadaFormatada.isEmpty,
                child: _botaoParaSorteioDePalavra(),
              ),
              Visibility(
                visible: _jogoStore.palavraAdivinhadaFormatada.isNotEmpty,
                child: _palavraParaAdivinhar(
                    palavra: _jogoStore.palavraAdivinhadaFormatada),
              ),
              Visibility(
                visible: _jogoStore.palavraAdivinhadaFormatada.isNotEmpty,
                child: _ajudaParaAdivinharAPalavra(
                    ajuda: _jogoStore.ajudaPalavraParaAdivinhar),
              ),
              _animacaoDaForca(animacao: _jogoStore.animacaoFlare),
              Visibility(
                visible: _jogoStore.palavraAdivinhadaFormatada.isNotEmpty,
                child: const TecladoJogoWidget(),
              ),
            ],
          );
        }),
      ),
      floatingActionButton: Observer(builder: (_) {
        return Visibility(
          visible: _jogoStore.palavraAdivinhadaFormatada.isEmpty,
          child: FloatingActionButton(
            onPressed: () => Navigator.of(context).pop(),
            child: const Icon(Icons.arrow_back),
          ),
        );
      }),
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
        onPressed: () => _jogoStore.selecionarPalavraParaAdivinhar(),
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
      child: FlareCacheBuilder([
        AssetFlare(
            bundle: rootBundle, name: 'assets/flare/forca_casa_do_codigo.flr')
      ], builder: (BuildContext context, bool isWarm) {
        return !isWarm
            ? const Center(
                child: Text(
                  "Carregando animação...",
                  textAlign: TextAlign.center,
                  style: TextStyle(
                    fontSize: 40,
                  ),
                ),
              )
            : FlareActor(
                "assets/flare/forca_casa_do_codigo.flr",
                alignment: Alignment.center,
                fit: BoxFit.contain,
                animation: animacao,
              );
      }),
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

  _ajudaParaAdivinharAPalavra({String? ajuda}) {
    return (ajuda != null)
        ? Padding(
            padding: const EdgeInsets.only(
              top: 10.0,
              bottom: 15,
            ),
            child: Text(ajuda),
          )
        : Container();
  }
}
