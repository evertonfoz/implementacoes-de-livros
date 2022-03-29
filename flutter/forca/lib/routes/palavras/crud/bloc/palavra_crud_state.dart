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
  List<Object> get props => [palavraModel];
}
