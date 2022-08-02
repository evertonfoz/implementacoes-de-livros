import 'package:flutter/material.dart';
import 'package:mobx/mobx.dart';

part 'produto_store.g.dart';

class ProdutoStore = _ProdutoStore with _$ProdutoStore;

abstract class _ProdutoStore with Store {
  @observable
  String? _nome;

  @observable
  String? _descricao;

  @observable
  double? _valor;

  @computed
  String get nome => _nome ?? '';

  @computed
  String get descricao => _descricao ?? '';

  @computed
  double get valor => _valor ?? 0;

  @computed
  bool get formOK => (nome.isNotEmpty && descricao.isNotEmpty && valor > 0);

  @action
  atualizarNome(String nome) {
    _nome = nome;
  }

  @action
  atualizarDescricao(String descricao) {
    _descricao = descricao;
  }

  @action
  atualizarValor(String valor) {
    _valor = double.tryParse(valor);
  }

  final TextEditingController nomeController = TextEditingController();
  final TextEditingController descricaoController = TextEditingController();
  final TextEditingController valorController = TextEditingController();

  resetForm() {
    nomeController.text = '';
    descricaoController.text = '';
    valorController.text = '';

    atualizarNome('');
    atualizarDescricao('');
    atualizarValor('');
  }
}
