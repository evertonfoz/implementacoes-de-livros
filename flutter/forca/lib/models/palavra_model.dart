import 'package:equatable/equatable.dart';

class PalavraModel extends Equatable {
  final String palavraID;
  final String palavra;
  final String ajuda;

  const PalavraModel({
    required this.palavraID,
    required this.palavra,
    required this.ajuda,
  });

  @override
  List<Object> get props => [palavraID];

  PalavraModel copyWith({
    String? palavraID,
    String? palavra,
    String? ajuda,
  }) {
    return PalavraModel(
      palavraID: palavraID ?? this.palavraID,
      palavra: palavra ?? this.palavra,
      ajuda: ajuda ?? this.ajuda,
    );
  }
}
