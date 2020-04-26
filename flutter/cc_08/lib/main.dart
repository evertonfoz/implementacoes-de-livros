import 'package:cc04/drawer/blocs/drawer_bloc.dart';
import 'package:cc04/routes/palavras/bloc/crud/palavras_crud_form_bloc.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'apphelpers/app_router.dart';
import 'routes/splash_screen_route.dart';

void main() => runApp(
      MultiBlocProvider(
        providers: [
          BlocProvider<DrawerOpenStateBloc>(
            create: (BuildContext context) => DrawerOpenStateBloc(),
          ),
          BlocProvider<PalavrasCrudFormBloc>(
            create: (BuildContext context) => PalavrasCrudFormBloc(),
          ),
        ],
        child: ForcaApp(),
      ),
    );

class ForcaApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      onGenerateRoute: AppRouter.generateRoute,
      debugShowCheckedModeBanner: false,
      title: 'Forca da UTFPR',
      theme: ThemeData(
        primarySwatch: Colors.blue,
        backgroundColor: Colors.green,
      ),
      home: ForcaHomePage(),
    );
  }
}

class ForcaHomePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SplashScreenRoute(),
    );
  }
}
