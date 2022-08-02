import '../../domain/entities/produto.dart';

// ignore: must_be_immutable
class ProdutoModel extends Produto {
  ProdutoModel({
    produtoID,
    required nome,
    required descricao,
    required valor,
  }) : super(
            produtoID: produtoID,
            nome: nome,
            descricao: descricao,
            valor: valor);

  factory ProdutoModel.fromMap(Map<String, Object?> map) {
    return ProdutoModel(
        produtoID: (map['produtoID'] as num).toInt(),
        nome: map['nome'] as String,
        descricao: map['descricao'] as String,
        valor: (map['valor'] as num).toDouble());
  }
}
