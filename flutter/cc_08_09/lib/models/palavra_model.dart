import 'package:equatable/equatable.dart';

class PalavraModel extends Equatable {
  final String palavraID;
  final String palavra;
  final String ajuda;

  @override
  List<Object> get props => [palavraID];

  PalavraModel({this.palavraID, this.palavra, this.ajuda});
}
