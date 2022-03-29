import 'package:capitulo03_splashscreen/models/palavra_model.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

abstract class PalavrasCRUDFormEvent {
  const PalavrasCRUDFormEvent();
}

class PalavrasCRUDPalavraChanged extends PalavrasCRUDFormEvent {
  final String palavra;

  const PalavrasCRUDPalavraChanged(this.palavra);
}

class PalavrasCRUDFormBloc extends Bloc<PalavrasCRUDFormEvent, PalavraModel?> {
  PalavrasCRUDFormBloc() : super(null) {
    on<PalavrasCRUDPalavraChanged>(_onPalavraChanged);
  }

  void _onPalavraChanged(
      PalavrasCRUDPalavraChanged event, Emitter<PalavraModel?> emit) {
    emit(state);
  }
}
