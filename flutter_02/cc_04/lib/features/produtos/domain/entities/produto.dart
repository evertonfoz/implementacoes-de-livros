import 'package:equatable/equatable.dart';

// ignore: must_be_immutable
class Produto extends Equatable {
  late int? produtoID;
  final String nome;
  final String descricao;
  final double valor;

  Produto({
    this.produtoID,
    required this.nome,
    required this.descricao,
    required this.valor,
  });

  @override
  List<Object> get props => [produtoID!];
}
