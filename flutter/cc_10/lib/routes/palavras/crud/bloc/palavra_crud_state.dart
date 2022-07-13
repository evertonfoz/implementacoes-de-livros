part of 'palavra_crud_bloc.dart';

abstract class PalavraCRUDState extends Equatable {
  const PalavraCRUDState();

  @override
  List<Object> get props => [];
}

class PalavraModelInitialized extends PalavraCRUDState {}

class PalavraChanged extends PalavraCRUDState {
  final PalavraModel palavraModel;

  const PalavraChanged({required this.palavraModel});

  @override
  List<Object> get props => [palavraModel.palavra];
}

class AjudaChanged extends PalavraCRUDState {
  final PalavraModel palavraModel;

  const AjudaChanged({required this.palavraModel});

  @override
  List<Object> get props => [palavraModel.ajuda];
}

class FormIsValidated extends PalavraCRUDState {
  final bool isValidated;

  const FormIsValidated({required this.isValidated});

  @override
  List<Object> get props => [
        isValidated,
      ];
}

class FormIsSubmitted extends PalavraCRUDState {}
