class PalavrasCrudFormModel {
  final String palavra;
  final bool aPalavraEhValida;
  final String ajuda;
  final bool aAjudaEhValida;
  final bool formularioEnviadoComSucesso;

  bool get isFormValid => aPalavraEhValida && aAjudaEhValida;

  const PalavrasCrudFormModel({
    required this.palavra,
    required this.aPalavraEhValida,
    required this.ajuda,
    required this.aAjudaEhValida,
    required this.formularioEnviadoComSucesso,
  });

  factory PalavrasCrudFormModel.initial() {
    return const PalavrasCrudFormModel(
        palavra: '',
        aPalavraEhValida: false,
        ajuda: '',
        aAjudaEhValida: false,
        formularioEnviadoComSucesso: false);
  }

  PalavrasCrudFormModel copyWith({
    String? palavra,
    bool? aPalavraEhValida,
    String? ajuda,
    bool? aAjudaEhValida,
    bool? formularioEnviadoComSucesso,
  }) {
    return PalavrasCrudFormModel(
        palavra: palavra ?? this.palavra,
        aPalavraEhValida: aPalavraEhValida ?? this.aPalavraEhValida,
        ajuda: ajuda ?? this.ajuda,
        aAjudaEhValida: aAjudaEhValida ?? this.aAjudaEhValida,
        formularioEnviadoComSucesso:
            formularioEnviadoComSucesso ?? this.formularioEnviadoComSucesso);
  }
}
