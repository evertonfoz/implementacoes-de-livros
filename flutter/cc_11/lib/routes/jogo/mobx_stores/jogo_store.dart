import 'dart:math';

import 'package:forca/local_persistence/daos/palavra_dao.dart';
import 'package:forca/models/palavra_model.dart';
import 'package:mobx/mobx.dart';

part 'jogo_store.g.dart';

class JogoStore = _JogoStore with _$JogoStore;

abstract class _JogoStore with Store {
  List<PalavraModel> _palavrasRegistradas = [];
  String palavraAdivinhada = '';

  int quantidadeErros = 0;

  @observable
  String animacaoFlare = 'idle';

  @observable
  bool ganhou = false;

  @observable
  bool perdeu = false;

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

    animacaoFlare = 'inicio';
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

  @action
  verificarExistenciaDaLetraNaPalavraParaAdivinhar({required String letra}) {
    int indexOfWord = palavraParaAdivinhar!.indexOf(letra, 0);
    if (indexOfWord < 0) {
      registrarErro();
      return;
    }

    while (indexOfWord >= 0) {
      palavraAdivinhada =
          palavraAdivinhada.replaceFirst('_', letra, indexOfWord);

      indexOfWord = palavraParaAdivinhar!.indexOf(letra, (indexOfWord + 1));
    }

    palavraAdivinhadaFormatada = _palavraAdivinhadaFormatada();

    if (!palavraAdivinhada.contains('_', 0)) {
      ganhou = true;
    }
  }

  @action
  registrarErro() {
    quantidadeErros++;
    if (quantidadeErros == 1) {
      animacaoFlare = 'cadeira';
    } else if (quantidadeErros == 2) {
      animacaoFlare = 'corpo';
    } else if (quantidadeErros == 3) {
      animacaoFlare = 'cabeca';
    } else if (quantidadeErros == 4) {
      animacaoFlare = 'balanco';
    } else if (quantidadeErros == 5) {
      animacaoFlare = 'enforcamento';
      Future.delayed(const Duration(seconds: 5)).then((_) {
        perdeu = true;
      });
    }
  }
}
