class PalavraModel {
  final String palavraID;
  final String palavra;
  final String ajuda;

  const PalavraModel({
    required this.palavraID,
    required this.palavra,
    required this.ajuda,
  });

  static PalavraModel empty() {
    return const PalavraModel(
      palavraID: '',
      palavra: '',
      ajuda: '',
    );
  }

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
