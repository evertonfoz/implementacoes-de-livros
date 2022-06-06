String removerAcentos(String s) {
  Map<String, String> letrasAcentuadas = {
    "â": "a",
    "Â": "A",
    "à": "a",
    "À": "A",
    "á": "a",
    "Á": "A",
    "ã": "a",
    "Ã": "A",
    "ê": "e",
    "Ê": "E",
    "è": "e",
    "È": "E",
    "é": "e",
    "É": "E",
    "î": "i",
    "Î": "I",
    "ì": "i",
    "Ì": "I",
    "í": "i",
    "Í": "I",
    "õ": "o",
    "Õ": "O",
    "ô": "o",
    "Ô": "O",
    "ò": "o",
    "Ò": "O",
    "ó": "o",
    "Ó": "O",
    "ü": "u",
    "Ü": "U",
    "û": "u",
    "Û": "U",
    "ú": "u",
    "Ú": "U",
    "ù": "u",
    "Ù": "U",
    "ç": "c",
    "Ç": "C"
  };

  List<String> origem = s.split('');
  for (int i = 0; i < origem.length; i++) {
    origem[i] = ((letrasAcentuadas[origem[i]] != null)
        ? letrasAcentuadas[origem[i]]
        : origem[i])!;
  }
  return origem.join();
}
