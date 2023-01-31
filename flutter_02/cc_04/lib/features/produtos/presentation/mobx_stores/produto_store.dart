import 'package:ec_delivery/features/produtos/data/models/produto_model.dart';
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

  @observable
  int? _produtoID;

  @computed
  int? get produtoID => _produtoID;

  @action
  atualizarProdutoID(int? produtoID) {
    _produtoID = produtoID;
  }

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
    atualizarProdutoID(null);

    atualizarNome('');
    atualizarDescricao('');
    atualizarValor('');
  }

  inicializarForm(ProdutoModel produto) {
    nomeController.text = produto.nome;
    descricaoController.text = produto.descricao;
    valorController.text = produto.valor.toString();

    atualizarNome(produto.nome);
    atualizarDescricao(produto.descricao);
    atualizarValor(produto.valor.toString());
    atualizarProdutoID(produto.produtoID);
  }
}
