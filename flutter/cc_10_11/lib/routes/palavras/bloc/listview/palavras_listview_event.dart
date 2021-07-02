abstract class PalavrasListViewBlocEvent {}

class PalavrasListViewBlocEventFetch extends PalavrasListViewBlocEvent {}

class PalavrasListViewBlocEventResetFetch extends PalavrasListViewBlocEvent {}

class PalavrasListViewBlocEventConfirmDismiss
    extends PalavrasListViewBlocEvent {
  final int indexOfDismissible;

  PalavrasListViewBlocEventConfirmDismiss({
    this.indexOfDismissible,
  });
}
