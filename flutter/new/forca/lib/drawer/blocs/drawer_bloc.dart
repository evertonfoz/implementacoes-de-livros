import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:equatable/equatable.dart';

abstract class DrawerState extends Equatable {
  const DrawerState();

  @override
  List<Object> get props => [];
}

abstract class DrawerEvent extends Equatable {
  const DrawerEvent();

  @override
  List<Object> get props => [];
}

class DrawerTooglePressed extends DrawerState {
  final bool isOpen;

  const DrawerTooglePressed({required this.isOpen});

  @override
  List<Object> get props => [isOpen];
}

class ToogleDrawer extends DrawerEvent {
  final bool isOpen;

  const ToogleDrawer({required this.isOpen});

  @override
  List<Object> get props => [isOpen];
}

class DrawerBloc extends Bloc<DrawerEvent, DrawerTooglePressed> {
  DrawerBloc() : super(const DrawerTooglePressed(isOpen: false)) {
    on<ToogleDrawer>(
        (event, emit) => emit(DrawerTooglePressed(isOpen: !event.isOpen)));
  }
}
