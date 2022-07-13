import 'dart:math';

import 'package:forca/local_persistence/daos/palavra_dao.dart';
import 'package:forca/models/palavra_model.dart';
import 'package:mobx/mobx.dart';

part 'jogo_store.g.dart';

class JogoStore = _JogoStore with _$JogoStore;

abstract class _JogoStore with Store {
  List<PalavraModel> _palavrasRegistradas = [];
  String palavraAdivinhada = '';

  @observable
  String? palavraParaAdivinhar;

  @observable
  String? ajudaPalavraParaAdivinhar;

  @observable
  String palavraAdivinhadaFormatada = '';

  @action
  _registrarPalavraParaAdivinhar(
      {required String palavra, required String ajuda}) {
    palavraParaAdivinhar = palavra.toUpperCase();
    ajudaPalavraParaAdivinhar = ajuda;
    palavraAdivinhada = _transformarPalavraParaAdivinhar();
    palavraAdivinhadaFormatada = _palavraAdivinhadaFormatada();
  }

  Future<List<PalavraModel>> _carregarPalavras() async {
    try {
      PalavraDAO palavraDAO = PalavraDAO();
      final List data = await palavraDAO.getAll();
      return data.map((palavra) {
        return PalavraModel.fromJson(palavra);
      }).toList();
    } catch (exception) {
      rethrow;
    }
  }

  selecionarPalavraParaAdivinhar() async {
    if (_palavrasRegistradas.isEmpty) {
      _palavrasRegistradas = await _carregarPalavras();
    }

    var random = Random();
    int indiceSorteado = random.nextInt(_palavrasRegistradas.length);
    PalavraModel palavraSelecionada = _palavrasRegistradas[indiceSorteado];

    _registrarPalavraParaAdivinhar(
        palavra: palavraSelecionada.palavra, ajuda: palavraSelecionada.ajuda);

    _palavrasRegistradas.removeAt(indiceSorteado);
  }

  _transformarPalavraParaAdivinhar() {
    String palavraFormatada = '';
    for (int i = 0; i < palavraParaAdivinhar!.length; i++) {
      if (palavraParaAdivinhar![i] != ' ') {
        palavraFormatada = palavraFormatada + '_';
      } else {
        palavraFormatada = palavraFormatada + ' ';
      }
    }
    return palavraFormatada;
  }

  _palavraAdivinhadaFormatada() {
    String palavraFormatada = '';
    for (int i = 0; i < palavraAdivinhada.length; i++) {
      palavraFormatada = '$palavraFormatada${palavraAdivinhada[i]} ';
    }
    return palavraFormatada;
  }
}
