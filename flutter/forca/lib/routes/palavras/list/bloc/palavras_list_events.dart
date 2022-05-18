part of 'palavras_list_bloc.dart';

abstract class PalavrasEvent extends Equatable {
  @override
  List<Object> get props => [];
}

class PalavrasFetched extends PalavrasEvent {}

class PalavrasResetFetch extends PalavrasEvent {}

// class PalavrasConfirmDismiss extends PalavrasEvent {
//   final int indexOfDismissible;

//   PalavrasConfirmDismiss({
//     required this.indexOfDismissible,
//   });
// }
