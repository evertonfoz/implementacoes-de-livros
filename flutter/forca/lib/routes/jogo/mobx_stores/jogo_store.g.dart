// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'jogo_store.dart';

// **************************************************************************
// StoreGenerator
// **************************************************************************

// ignore_for_file: non_constant_identifier_names, unnecessary_brace_in_string_interps, unnecessary_lambdas, prefer_expression_function_bodies, lines_longer_than_80_chars, avoid_as, avoid_annotating_with_dynamic, no_leading_underscores_for_local_identifiers

mixin _$JogoStore on _JogoStore, Store {
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

  late final _$_JogoStoreActionController =
      ActionController(name: '_JogoStore', context: context);

  @override
  dynamic registrarPalavraParaAdivinhar(
      {required String palavra, required String ajuda}) {
    final _$actionInfo = _$_JogoStoreActionController.startAction(
        name: '_JogoStore.registrarPalavraParaAdivinhar');
    try {
      return super
          .registrarPalavraParaAdivinhar(palavra: palavra, ajuda: ajuda);
    } finally {
      _$_JogoStoreActionController.endAction(_$actionInfo);
    }
  }

  @override
  String toString() {
    return '''
palavraParaAdivinhar: ${palavraParaAdivinhar},
ajudaPalavraParaAdivinhar: ${ajudaPalavraParaAdivinhar}
    ''';
  }
}
