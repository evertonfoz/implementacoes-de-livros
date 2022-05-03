import 'package:bloc/bloc.dart';
import 'package:capitulo03_splashscreen/local_persistence/daos/palavra_dao.dart';
import 'package:capitulo03_splashscreen/models/palavra_model.dart';
import 'package:equatable/equatable.dart';
import 'package:stream_transform/stream_transform.dart';
import 'package:bloc_concurrency/bloc_concurrency.dart';

part 'palavras_list_events.dart';
part 'palavras_list_states.dart';

const _palavrasLimit = 20;
const throttleDuration = Duration(milliseconds: 100);

EventTransformer<E> throttleDroppable<E>(Duration duration) {
  return (events, mapper) {
    return droppable<E>().call(events.throttle(duration), mapper);
  };
}

class PalavrasBloc extends Bloc<PalavrasEvent, PalavrasLISTState> {
  final PalavraDAO palavraDAO;

  PalavrasBloc({required this.palavraDAO}) : super(const PalavrasLISTState()) {
    on<PalavrasFetched>(
      _onPalavrasFetched,
      transformer: throttleDroppable(throttleDuration),
    );
  }

  Future<void> _onPalavrasFetched(
      PalavrasFetched event, Emitter<PalavrasLISTState> emit) async {
    if (state.hasReachedMax) return;
    try {
      if (state.status == PalavrasStatus.initial) {
        final palavras = await _fetchPalavras();
        return emit(state.copyWith(
          status: PalavrasStatus.success,
          palavras: palavras,
          hasReachedMax: false,
        ));
      }
      final posts = await _fetchPalavras(state.palavras.length);
      emit(posts.isEmpty
          ? state.copyWith(hasReachedMax: true)
          : state.copyWith(
              status: PalavrasStatus.success,
              palavras: List.of(state.palavras)..addAll(posts),
              hasReachedMax: false,
            ));
    } catch (_) {
      emit(state.copyWith(status: PalavrasStatus.failure));
    }
  }

  Future<List<PalavraModel>> _fetchPalavras([int startIndex = 0]) async {
    try {
      final List mapOfPalavras = await PalavraDAO()
          .getAll(startIndex: startIndex, limit: _palavrasLimit);

      List<PalavraModel> palavras =
          mapOfPalavras.map((e) => PalavraModel.fromJson(e)).toList();
      return palavras;
    } on Exception {
      throw Exception('Erro recuperando palavras');
    }
  }
}
