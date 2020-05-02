// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'teclado_store.dart';

// **************************************************************************
// StoreGenerator
// **************************************************************************

// ignore_for_file: non_constant_identifier_names, unnecessary_lambdas, prefer_expression_function_bodies, lines_longer_than_80_chars, avoid_as, avoid_annotating_with_dynamic

mixin _$TecladoStore on _TecladoStore, Store {
  final _$widgetsDeLetrasDoTecladoAtom =
      Atom(name: '_TecladoStore.widgetsDeLetrasDoTeclado');

  @override
  ObservableList<LetraTecladoJogoWidget> get widgetsDeLetrasDoTeclado {
    _$widgetsDeLetrasDoTecladoAtom.context
        .enforceReadPolicy(_$widgetsDeLetrasDoTecladoAtom);
    _$widgetsDeLetrasDoTecladoAtom.reportObserved();
    return super.widgetsDeLetrasDoTeclado;
  }

  @override
  set widgetsDeLetrasDoTeclado(ObservableList<LetraTecladoJogoWidget> value) {
    _$widgetsDeLetrasDoTecladoAtom.context.conditionallyRunInAction(() {
      super.widgetsDeLetrasDoTeclado = value;
      _$widgetsDeLetrasDoTecladoAtom.reportChanged();
    }, _$widgetsDeLetrasDoTecladoAtom,
        name: '${_$widgetsDeLetrasDoTecladoAtom.name}_set');
  }

  final _$_TecladoStoreActionController =
      ActionController(name: '_TecladoStore');

  @override
  dynamic inicializarTeclado({String letrasParaTeclado}) {
    final _$actionInfo = _$_TecladoStoreActionController.startAction();
    try {
      return super.inicializarTeclado(letrasParaTeclado: letrasParaTeclado);
    } finally {
      _$_TecladoStoreActionController.endAction(_$actionInfo);
    }
  }

  @override
  dynamic letraPressionada({int indiceDaLetra}) {
    final _$actionInfo = _$_TecladoStoreActionController.startAction();
    try {
      return super.letraPressionada(indiceDaLetra: indiceDaLetra);
    } finally {
      _$_TecladoStoreActionController.endAction(_$actionInfo);
    }
  }

  @override
  String toString() {
    final string =
        'widgetsDeLetrasDoTeclado: ${widgetsDeLetrasDoTeclado.toString()}';
    return '{$string}';
  }
}
