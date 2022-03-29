import 'package:capitulo03_splashscreen/models/palavra_model.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

abstract class PalavraEvent {}

class PalavraChanged extends PalavraEvent {}

class AjudaChanged extends PalavraEvent {}

class PalavraFormSuccessSubmitted extends PalavraEvent {}

class PalavraFormReset extends PalavraEvent {}

class PalavraBloc extends Bloc<PalavraEvent, PalavraModel?> {
  PalavraBloc() : super(null) {
    on<PalavraChanged>((event, emit) => emit(state));
    on<AjudaChanged>((event, emit) => emit(state));
    on<PalavraFormSuccessSubmitted>((event, emit) => emit(state));
    on<PalavraFormReset>((event, emit) => emit(state));
  }
}
