// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'jogo_store.dart';

// **************************************************************************
// StoreGenerator
// **************************************************************************

// ignore_for_file: non_constant_identifier_names, unnecessary_lambdas, prefer_expression_function_bodies, lines_longer_than_80_chars, avoid_as, avoid_annotating_with_dynamic

mixin _$JogoStore on _JogoStore, Store {
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

  @override
  String toString() {
    final string =
        'palavraParaAdivinhar: ${palavraParaAdivinhar.toString()},ajudaPalavraParaAdivinhar: ${ajudaPalavraParaAdivinhar.toString()}';
    return '{$string}';
  }
}
