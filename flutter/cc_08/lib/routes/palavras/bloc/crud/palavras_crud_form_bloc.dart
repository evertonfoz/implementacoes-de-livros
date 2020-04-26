import 'package:flutter_bloc/flutter_bloc.dart';
import 'palavras_crud_form_event.dart';
import 'palavras_crud_form_state.dart';

class PalavrasCrudFormBloc
    extends Bloc<PalavrasCrudFormEvent, PalavrasCrudFormState> {
  @override
  PalavrasCrudFormState get initialState => PalavrasCrudFormState.initial();

  @override
  Stream<PalavrasCrudFormState> mapEventToState(
    PalavrasCrudFormEvent event,
  ) async* {
    if (event is PalavraChanged) {
      yield state.copyWith(
        palavra: event.palavra,
        aPalavraEhValida: _aPalavraEhValida(event.palavra),
      );
    } else if (event is AjudaChanged) {
      yield state.copyWith(
        ajuda: event.ajuda,
        aAjudaEhValida: _aAjudaEhValida(event.ajuda),
      );
    } else if (event is FormSuccessSubmitted) {
      yield state.copyWith(formularioEnviadoComSucesso: true);
    } else if (event is FormReset) {
      yield PalavrasCrudFormState.initial();
    }
  }

  bool _aPalavraEhValida(String palavra) {
    return palavra.isNotEmpty;
  }

  bool _aAjudaEhValida(String ajuda) {
    return ajuda.isNotEmpty;
  }
}
