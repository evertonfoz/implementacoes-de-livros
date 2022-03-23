import 'package:equatable/equatable.dart';

class PalavraModel extends Equatable {
  final String palavraID;
  final String palavra;
  final String ajuda;

  const PalavraModel(
      {required this.palavraID, required this.palavra, required this.ajuda});

  @override
  List<Object> get props => [palavraID];
}
