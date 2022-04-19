import 'package:flutter_bloc/flutter_bloc.dart';

abstract class DrawerEvent {}

class DrawerShowPressed extends DrawerEvent {}

class DrawerHidePressed extends DrawerEvent {}

class DrawerBloc extends Bloc<DrawerEvent, bool> {
  DrawerBloc() : super(false) {
    on<DrawerShowPressed>((event, emit) => emit(!state));
    on<DrawerHidePressed>((event, emit) => emit(!state));
  }
}
