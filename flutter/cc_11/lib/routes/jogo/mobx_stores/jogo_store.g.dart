// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'jogo_store.dart';

// **************************************************************************
// StoreGenerator
// **************************************************************************

// ignore_for_file: non_constant_identifier_names, unnecessary_brace_in_string_interps, unnecessary_lambdas, prefer_expression_function_bodies, lines_longer_than_80_chars, avoid_as, avoid_annotating_with_dynamic, no_leading_underscores_for_local_identifiers

mixin _$JogoStore on _JogoStore, Store {
  late final _$animacaoFlareAtom =
      Atom(name: '_JogoStore.animacaoFlare', context: context);

  @override
  String get animacaoFlare {
    _$animacaoFlareAtom.reportRead();
    return super.animacaoFlare;
  }

  @override
  set animacaoFlare(String value) {
    _$animacaoFlareAtom.reportWrite(value, super.animacaoFlare, () {
      super.animacaoFlare = value;
    });
  }

  late final _$perdeuAtom = Atom(name: '_JogoStore.perdeu', context: context);

  @override
  bool get perdeu {
    _$perdeuAtom.reportRead();
    return super.perdeu;
  }

  @override
  set perdeu(bool value) {
    _$perdeuAtom.reportWrite(value, super.perdeu, () {
      super.perdeu = value;
    });
  }

  late final _$palavraParaAdivinharAtom =
      Atom(name: '_JogoStore.palavraParaAdivinhar', context: context);

  @override
  String? get palavraParaAdivinhar {
    _$palavraParaAdivinharAtom.reportRead();
    return super.palavraParaAdivinhar;
  }

  @override
  set palavraParaAdivinhar(String? value) {
    _$palavraParaAdivinharAtom.reportWrite(value, super.palavraParaAdivinhar,
        () {
      super.palavraParaAdivinhar = value;
    });
  }

  late final _$ajudaPalavraParaAdivinharAtom =
      Atom(name: '_JogoStore.ajudaPalavraParaAdivinhar', context: context);

  @override
  String? get ajudaPalavraParaAdivinhar {
    _$ajudaPalavraParaAdivinharAtom.reportRead();
    return super.ajudaPalavraParaAdivinhar;
  }

  @override
  set ajudaPalavraParaAdivinhar(String? value) {
    _$ajudaPalavraParaAdivinharAtom
        .reportWrite(value, super.ajudaPalavraParaAdivinhar, () {
      super.ajudaPalavraParaAdivinhar = value;
    });
  }

  late final _$ganhouAtom = Atom(name: '_JogoStore.ganhou', context: context);

  @override
  bool get ganhou {
    _$ganhouAtom.reportRead();
    return super.ganhou;
  }

  @override
  set ganhou(bool value) {
    _$ganhouAtom.reportWrite(value, super.ganhou, () {
      super.ganhou = value;
    });
  }

  late final _$palavraAdivinhadaFormatadaAtom =
      Atom(name: '_JogoStore.palavraAdivinhadaFormatada', context: context);

  @override
  String get palavraAdivinhadaFormatada {
    _$palavraAdivinhadaFormatadaAtom.reportRead();
    return super.palavraAdivinhadaFormatada;
  }

  @override
  set palavraAdivinhadaFormatada(String value) {
    _$palavraAdivinhadaFormatadaAtom
        .reportWrite(value, super.palavraAdivinhadaFormatada, () {
      super.palavraAdivinhadaFormatada = value;
    });
  }

  late final _$_JogoStoreActionController =
      ActionController(name: '_JogoStore', context: context);

  @override
  dynamic _registrarPalavraParaAdivinhar(
      {required String palavra, required String ajuda}) {
    final _$actionInfo = _$_JogoStoreActionController.startAction(
        name: '_JogoStore._registrarPalavraParaAdivinhar');
    try {
      return super
          ._registrarPalavraParaAdivinhar(palavra: palavra, ajuda: ajuda);
    } finally {
      _$_JogoStoreActionController.endAction(_$actionInfo);
    }
  }

  @override
  dynamic verificarExistenciaDaLetraNaPalavraParaAdivinhar(
      {required String letra}) {
    final _$actionInfo = _$_JogoStoreActionController.startAction(
        name: '_JogoStore.verificarExistenciaDaLetraNaPalavraParaAdivinhar');
    try {
      return super
          .verificarExistenciaDaLetraNaPalavraParaAdivinhar(letra: letra);
    } finally {
      _$_JogoStoreActionController.endAction(_$actionInfo);
    }
  }

  @override
  dynamic registrarErro() {
    final _$actionInfo = _$_JogoStoreActionController.startAction(
        name: '_JogoStore.registrarErro');
    try {
      return super.registrarErro();
    } finally {
      _$_JogoStoreActionController.endAction(_$actionInfo);
    }
  }

  @override
  String toString() {
    return '''
animacaoFlare: ${animacaoFlare},
perdeu: ${perdeu},
palavraParaAdivinhar: ${palavraParaAdivinhar},
ajudaPalavraParaAdivinhar: ${ajudaPalavraParaAdivinhar},
ganhou: ${ganhou},
palavraAdivinhadaFormatada: ${palavraAdivinhadaFormatada}
    ''';
  }
}
