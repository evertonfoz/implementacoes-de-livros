part of 'palavras_list_bloc.dart';

abstract class PalavrasEvent extends Equatable {
  @override
  List<Object> get props => [];
}

class PalavrasFetched extends PalavrasEvent {}
