import 'package:capitulo03_splashscreen/routes/jogo/widgets/letra_teclado_jogo_widget.dart';
import 'package:mobx/mobx.dart';

part 'teclado_store.g.dart';

class TecladoStore = _TecladoStore with _$TecladoStore;

abstract class _TecladoStore with Store {
  @observable
  ObservableList<LetraTecladoJogoWidget> widgetsDeLetrasDoTeclado =
      ObservableList<LetraTecladoJogoWidget>();

  @action
  inicializarTeclado({required String letrasParaTeclado}) {
    for (int i = 0; i < letrasParaTeclado.length; i++) {
      widgetsDeLetrasDoTeclado.add(
        LetraTecladoJogoWidget(
          letra: letrasParaTeclado[i],
        ),
      );
    }
  }

  @action
  letraPressionada({required int indiceDaLetra}) {
    widgetsDeLetrasDoTeclado[indiceDaLetra] =
        widgetsDeLetrasDoTeclado[indiceDaLetra].copyWith(
      letra: widgetsDeLetrasDoTeclado[indiceDaLetra].letra,
      foiUtilizada: true,
    );
  }
}
