import 'package:flutter_bloc/flutter_bloc.dart';

class DrawerCubit extends Cubit<bool> {
  DrawerCubit() : super(false);

  void openDrawer() => emit(!state);
  void closeDrawer() => emit(!state);
}
