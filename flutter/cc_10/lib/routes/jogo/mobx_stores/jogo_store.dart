import 'dart:math';

import 'package:cc04/local_persistence/daos/palavra_dao.dart';
import 'package:cc04/models/palavra_model.dart';
import 'package:mobx/mobx.dart';

part 'jogo_store.g.dart';

class JogoStore = _JogoStore with _$JogoStore;

abstract class _JogoStore with Store {
  List<PalavraModel> _palavrasRegistradas = [];
  String palavraAdivinhada = '';

  @observable
  String palavraParaAdivinhar;

  @observable
  String ajudaPalavraParaAdivinhar;

  @observable
  String palavraAdivinhadaFormatada = '';

  @action
  _registrarPalavraParaAdivinhar({String palavra, String ajuda}) {
    this.palavraParaAdivinhar = palavra.toUpperCase();
    this.ajudaPalavraParaAdivinhar = ajuda;
    this.palavraAdivinhada = _transformarPalavraParaAdivinhar();
    this.palavraAdivinhadaFormatada = _palavraAdivinhadaFormatada();
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
    if (this._palavrasRegistradas.length == 0)
      this._palavrasRegistradas = await _carregarPalavras();

    var random = new Random();
    int indiceSorteado = random.nextInt(this._palavrasRegistradas.length);
    PalavraModel palavraSelecionada = this._palavrasRegistradas[indiceSorteado];

    _registrarPalavraParaAdivinhar(
        palavra: palavraSelecionada.palavra, ajuda: palavraSelecionada.ajuda);

    this._palavrasRegistradas.removeAt(indiceSorteado);
  }

  _transformarPalavraParaAdivinhar() {
    String palavraFormatada = '';
    for (int i = 0; i < this.palavraParaAdivinhar.length; i++) {
      if (this.palavraParaAdivinhar[i] != ' ')
        palavraFormatada = palavraFormatada + '_';
      else
        palavraFormatada = palavraFormatada + ' ';
    }
    return palavraFormatada;
  }

  _palavraAdivinhadaFormatada() {
    String palavraFormatada = '';
    for (int i = 0; i < this.palavraAdivinhada.length; i++) {
      palavraFormatada = palavraFormatada + this.palavraAdivinhada[i] + ' ';
    }
    return palavraFormatada;
  }
}
