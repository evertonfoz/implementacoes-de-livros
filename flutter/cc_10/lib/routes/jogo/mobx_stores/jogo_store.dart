import 'package:mobx/mobx.dart';

part 'jogo_store.g.dart';

class JogoStore = _JogoStore with _$JogoStore;

abstract class _JogoStore with Store {
  @observable
  String palavraParaAdivinhar;

  @observable
  String ajudaPalavraParaAdivinhar;
}
