import 'package:meta/meta.dart';

abstract class PalavrasCrudFormEvent {
  const PalavrasCrudFormEvent();
}

class PalavraChanged extends PalavrasCrudFormEvent {
  final String palavra;

  const PalavraChanged({@required this.palavra});
}

class AjudaChanged extends PalavrasCrudFormEvent {
  final String ajuda;

  const AjudaChanged({@required this.ajuda});
}

class FormSuccessSubmitted extends PalavrasCrudFormEvent {}

class FormReset extends PalavrasCrudFormEvent {}
