part of 'palavras_list_bloc.dart';

enum PalavrasStatus { initial, success, failure }

class PalavrasState extends Equatable {
  const PalavrasState({
    this.status = PalavrasStatus.initial,
    this.palavras = const <PalavraModel>[],
    this.hasReachedMax = false,
  });

  final PalavrasStatus status;
  final List<PalavraModel> palavras;
  final bool hasReachedMax;

  PalavrasState copyWith({
    PalavrasStatus? status,
    List<PalavraModel>? palavras,
    bool? hasReachedMax,
  }) {
    return PalavrasState(
      status: status ?? this.status,
      palavras: palavras ?? this.palavras,
      hasReachedMax: hasReachedMax ?? this.hasReachedMax,
    );
  }

  @override
  String toString() {
    return '''PostState { status: $status, hasReachedMax: $hasReachedMax, posts: ${palavras.length} }''';
  }

  @override
  List<Object> get props => [status, palavras, hasReachedMax];
}
