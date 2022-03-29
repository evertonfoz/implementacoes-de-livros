import 'dart:async';

enum PalavraFormCRUDStatus {
  palavraChanged,
  ajudaChanged,
  formSuccessSubmitted,
  formReset
}

class PalavraCRUDController {
  final _controller = StreamController<PalavraFormCRUDStatus>();

  void palavraChanged({
    required String palavra,
  }) async {
    _controller.add(PalavraFormCRUDStatus.palavraChanged);
  }

  void dispose() => _controller.close();
}
