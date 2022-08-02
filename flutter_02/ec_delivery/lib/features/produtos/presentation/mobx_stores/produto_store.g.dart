// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'produto_store.dart';

// **************************************************************************
// StoreGenerator
// **************************************************************************

// ignore_for_file: non_constant_identifier_names, unnecessary_brace_in_string_interps, unnecessary_lambdas, prefer_expression_function_bodies, lines_longer_than_80_chars, avoid_as, avoid_annotating_with_dynamic, no_leading_underscores_for_local_identifiers

mixin _$ProdutoStore on _ProdutoStore, Store {
  Computed<String>? _$nomeComputed;

  @override
  String get nome => (_$nomeComputed ??=
          Computed<String>(() => super.nome, name: '_ProdutoStore.nome'))
      .value;
  Computed<String>? _$descricaoComputed;

  @override
  String get descricao =>
      (_$descricaoComputed ??= Computed<String>(() => super.descricao,
              name: '_ProdutoStore.descricao'))
          .value;
  Computed<double>? _$valorComputed;

  @override
  double get valor => (_$valorComputed ??=
          Computed<double>(() => super.valor, name: '_ProdutoStore.valor'))
      .value;
  Computed<bool>? _$formOKComputed;

  @override
  bool get formOK => (_$formOKComputed ??=
          Computed<bool>(() => super.formOK, name: '_ProdutoStore.formOK'))
      .value;

  late final _$_nomeAtom = Atom(name: '_ProdutoStore._nome', context: context);

  @override
  String? get _nome {
    _$_nomeAtom.reportRead();
    return super._nome;
  }

  @override
  set _nome(String? value) {
    _$_nomeAtom.reportWrite(value, super._nome, () {
      super._nome = value;
    });
  }

  late final _$_descricaoAtom =
      Atom(name: '_ProdutoStore._descricao', context: context);

  @override
  String? get _descricao {
    _$_descricaoAtom.reportRead();
    return super._descricao;
  }

  @override
  set _descricao(String? value) {
    _$_descricaoAtom.reportWrite(value, super._descricao, () {
      super._descricao = value;
    });
  }

  late final _$_valorAtom =
      Atom(name: '_ProdutoStore._valor', context: context);

  @override
  double? get _valor {
    _$_valorAtom.reportRead();
    return super._valor;
  }

  @override
  set _valor(double? value) {
    _$_valorAtom.reportWrite(value, super._valor, () {
      super._valor = value;
    });
  }

  late final _$_ProdutoStoreActionController =
      ActionController(name: '_ProdutoStore', context: context);

  @override
  dynamic atualizarNome(String nome) {
    final _$actionInfo = _$_ProdutoStoreActionController.startAction(
        name: '_ProdutoStore.atualizarNome');
    try {
      return super.atualizarNome(nome);
    } finally {
      _$_ProdutoStoreActionController.endAction(_$actionInfo);
    }
  }

  @override
  dynamic atualizarDescricao(String descricao) {
    final _$actionInfo = _$_ProdutoStoreActionController.startAction(
        name: '_ProdutoStore.atualizarDescricao');
    try {
      return super.atualizarDescricao(descricao);
    } finally {
      _$_ProdutoStoreActionController.endAction(_$actionInfo);
    }
  }

  @override
  dynamic atualizarValor(String valor) {
    final _$actionInfo = _$_ProdutoStoreActionController.startAction(
        name: '_ProdutoStore.atualizarValor');
    try {
      return super.atualizarValor(valor);
    } finally {
      _$_ProdutoStoreActionController.endAction(_$actionInfo);
    }
  }

  @override
  String toString() {
    return '''
nome: ${nome},
descricao: ${descricao},
valor: ${valor},
formOK: ${formOK}
    ''';
  }
}
