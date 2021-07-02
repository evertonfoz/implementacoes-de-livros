import 'package:bloc/bloc.dart';
import 'drawer_bloc_enums.dart';

class DrawerOpenStateBloc extends Bloc<DrawerControllerEvent, bool> {
  @override
  bool get initialState => false;

  @override
  Stream<bool> mapEventToState(DrawerControllerEvent event) async* {
    switch (event) {
      case DrawerControllerEvent.open:
        yield true;
        break;
      case DrawerControllerEvent.close:
        yield false;
        break;
    }
  }
}
