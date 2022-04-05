part of 'palavra_crud_bloc.dart';

abstract class PalavraCRUDEvent extends Equatable {
  const PalavraCRUDEvent();

  @override
  List<Object> get props => [];
}

class ChangePalavra extends PalavraCRUDEvent {
  final PalavraModel palavraModel;

  const ChangePalavra({required this.palavraModel});

  @override
  List<Object> get props => [palavraModel.palavra];
}

class ChangeAjuda extends PalavraCRUDEvent {
  final PalavraModel palavraModel;

  const ChangeAjuda({required this.palavraModel});

  @override
  List<Object> get props => [palavraModel.ajuda];
}

class ValidateForm extends PalavraCRUDEvent {
  final PalavraModel palavraModel;

  const ValidateForm({required this.palavraModel});

  @override
  List<Object> get props => [
        palavraModel.palavraID,
        palavraModel.palavra,
        palavraModel.ajuda,
      ];
}

class SubmitForm extends PalavraCRUDEvent {}
