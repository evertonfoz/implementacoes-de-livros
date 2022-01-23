import 'package:cc04/models/palavra_model.dart';

abstract class PalavrasListViewBlocState {
  const PalavrasListViewBlocState();
}

class PalavrasListViewBlocUninitialized extends PalavrasListViewBlocState {}

class PalavrasListViewBlocError extends PalavrasListViewBlocState {
  final errorMessage;

  PalavrasListViewBlocError({this.errorMessage});
}

class PalavrasListViewLoaded extends PalavrasListViewBlocState {
  final List<PalavraModel> palavras;
  final bool hasReachedMax;

  const PalavrasListViewLoaded({
    this.palavras,
    this.hasReachedMax,
  });

  PalavrasListViewLoaded copyWith({
    List<PalavraModel> palavras,
    bool hasReachedMax,
  }) {
    return PalavrasListViewLoaded(
      palavras: palavras ?? this.palavras,
      hasReachedMax: hasReachedMax ?? this.hasReachedMax,
    );
  }

  @override
  String toString() =>
      'PalavrasListViewLoaded { palavras: ${palavras.length}, hasReachedMax: $hasReachedMax }';
}
