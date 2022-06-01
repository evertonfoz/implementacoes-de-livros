// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'teclado_store.dart';

// **************************************************************************
// StoreGenerator
// **************************************************************************

// ignore_for_file: non_constant_identifier_names, unnecessary_brace_in_string_interps, unnecessary_lambdas, prefer_expression_function_bodies, lines_longer_than_80_chars, avoid_as, avoid_annotating_with_dynamic, no_leading_underscores_for_local_identifiers

mixin _$TecladoStore on _TecladoStore, Store {
  late final _$widgetsDeLetrasDoTecladoAtom =
      Atom(name: '_TecladoStore.widgetsDeLetrasDoTeclado', context: context);

  @override
  ObservableList<LetraTecladoJogoWidget> get widgetsDeLetrasDoTeclado {
    _$widgetsDeLetrasDoTecladoAtom.reportRead();
    return super.widgetsDeLetrasDoTeclado;
  }

  @override
  set widgetsDeLetrasDoTeclado(ObservableList<LetraTecladoJogoWidget> value) {
    _$widgetsDeLetrasDoTecladoAtom
        .reportWrite(value, super.widgetsDeLetrasDoTeclado, () {
      super.widgetsDeLetrasDoTeclado = value;
    });
  }

  late final _$_TecladoStoreActionController =
      ActionController(name: '_TecladoStore', context: context);

  @override
  dynamic inicializarTeclado({required String letrasParaTeclado}) {
    final _$actionInfo = _$_TecladoStoreActionController.startAction(
        name: '_TecladoStore.inicializarTeclado');
    try {
      return super.inicializarTeclado(letrasParaTeclado: letrasParaTeclado);
    } finally {
      _$_TecladoStoreActionController.endAction(_$actionInfo);
    }
  }

  @override
  dynamic letraPressionada({required int indiceDaLetra}) {
    final _$actionInfo = _$_TecladoStoreActionController.startAction(
        name: '_TecladoStore.letraPressionada');
    try {
      return super.letraPressionada(indiceDaLetra: indiceDaLetra);
    } finally {
      _$_TecladoStoreActionController.endAction(_$actionInfo);
    }
  }

  @override
  String toString() {
    return '''
widgetsDeLetrasDoTeclado: ${widgetsDeLetrasDoTeclado}
    ''';
  }
}
