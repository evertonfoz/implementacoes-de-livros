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
