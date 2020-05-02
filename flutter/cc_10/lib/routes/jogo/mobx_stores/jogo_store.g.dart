// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'jogo_store.dart';

// **************************************************************************
// StoreGenerator
// **************************************************************************

// ignore_for_file: non_constant_identifier_names, unnecessary_lambdas, prefer_expression_function_bodies, lines_longer_than_80_chars, avoid_as, avoid_annotating_with_dynamic

mixin _$JogoStore on _JogoStore, Store {
  final _$animacaoFlareAtom = Atom(name: '_JogoStore.animacaoFlare');

  @override
  String get animacaoFlare {
    _$animacaoFlareAtom.context.enforceReadPolicy(_$animacaoFlareAtom);
    _$animacaoFlareAtom.reportObserved();
    return super.animacaoFlare;
  }

  @override
  set animacaoFlare(String value) {
    _$animacaoFlareAtom.context.conditionallyRunInAction(() {
      super.animacaoFlare = value;
      _$animacaoFlareAtom.reportChanged();
    }, _$animacaoFlareAtom, name: '${_$animacaoFlareAtom.name}_set');
  }

  final _$palavraParaAdivinharAtom =
      Atom(name: '_JogoStore.palavraParaAdivinhar');

  @override
  String get palavraParaAdivinhar {
    _$palavraParaAdivinharAtom.context
        .enforceReadPolicy(_$palavraParaAdivinharAtom);
    _$palavraParaAdivinharAtom.reportObserved();
    return super.palavraParaAdivinhar;
  }

  @override
  set palavraParaAdivinhar(String value) {
    _$palavraParaAdivinharAtom.context.conditionallyRunInAction(() {
      super.palavraParaAdivinhar = value;
      _$palavraParaAdivinharAtom.reportChanged();
    }, _$palavraParaAdivinharAtom,
        name: '${_$palavraParaAdivinharAtom.name}_set');
  }

  final _$ajudaPalavraParaAdivinharAtom =
      Atom(name: '_JogoStore.ajudaPalavraParaAdivinhar');

  @override
  String get ajudaPalavraParaAdivinhar {
    _$ajudaPalavraParaAdivinharAtom.context
        .enforceReadPolicy(_$ajudaPalavraParaAdivinharAtom);
    _$ajudaPalavraParaAdivinharAtom.reportObserved();
    return super.ajudaPalavraParaAdivinhar;
  }

  @override
  set ajudaPalavraParaAdivinhar(String value) {
    _$ajudaPalavraParaAdivinharAtom.context.conditionallyRunInAction(() {
      super.ajudaPalavraParaAdivinhar = value;
      _$ajudaPalavraParaAdivinharAtom.reportChanged();
    }, _$ajudaPalavraParaAdivinharAtom,
        name: '${_$ajudaPalavraParaAdivinharAtom.name}_set');
  }

  final _$palavraAdivinhadaFormatadaAtom =
      Atom(name: '_JogoStore.palavraAdivinhadaFormatada');

  @override
  String get palavraAdivinhadaFormatada {
    _$palavraAdivinhadaFormatadaAtom.context
        .enforceReadPolicy(_$palavraAdivinhadaFormatadaAtom);
    _$palavraAdivinhadaFormatadaAtom.reportObserved();
    return super.palavraAdivinhadaFormatada;
  }

  @override
  set palavraAdivinhadaFormatada(String value) {
    _$palavraAdivinhadaFormatadaAtom.context.conditionallyRunInAction(() {
      super.palavraAdivinhadaFormatada = value;
      _$palavraAdivinhadaFormatadaAtom.reportChanged();
    }, _$palavraAdivinhadaFormatadaAtom,
        name: '${_$palavraAdivinhadaFormatadaAtom.name}_set');
  }

  final _$_JogoStoreActionController = ActionController(name: '_JogoStore');

  @override
  dynamic _registrarPalavraParaAdivinhar({String palavra, String ajuda}) {
    final _$actionInfo = _$_JogoStoreActionController.startAction();
    try {
      return super
          ._registrarPalavraParaAdivinhar(palavra: palavra, ajuda: ajuda);
    } finally {
      _$_JogoStoreActionController.endAction(_$actionInfo);
    }
  }

  @override
  dynamic verificarExistenciaDaLetraNaPalavraParaAdivinhar({String letra}) {
    final _$actionInfo = _$_JogoStoreActionController.startAction();
    try {
      return super
          .verificarExistenciaDaLetraNaPalavraParaAdivinhar(letra: letra);
    } finally {
      _$_JogoStoreActionController.endAction(_$actionInfo);
    }
  }

  @override
  dynamic registrarErro() {
    final _$actionInfo = _$_JogoStoreActionController.startAction();
    try {
      return super.registrarErro();
    } finally {
      _$_JogoStoreActionController.endAction(_$actionInfo);
    }
  }

  @override
  String toString() {
    final string =
        'animacaoFlare: ${animacaoFlare.toString()},palavraParaAdivinhar: ${palavraParaAdivinhar.toString()},ajudaPalavraParaAdivinhar: ${ajudaPalavraParaAdivinhar.toString()},palavraAdivinhadaFormatada: ${palavraAdivinhadaFormatada.toString()}';
    return '{$string}';
  }
}
