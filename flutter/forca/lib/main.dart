import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'apphelpers/app_router.dart';
import 'drawer/blocs/drawer_bloc.dart';
import 'local_persistence/daos/palavra_dao.dart';
import 'routes/palavras/crud/bloc/palavra_crud_bloc.dart';
import 'routes/palavras/list/bloc/palavras_list_bloc.dart';
import 'routes/splash_screen_route.dart';

void main() => runApp(const ForcaApp());

class ForcaApp extends StatelessWidget {
  const ForcaApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MultiBlocProvider(
      providers: [
        BlocProvider(
          create: (_) => DrawerBloc(),
        ),
        BlocProvider(create: (_) => PalavraBloc()),
        BlocProvider<PalavrasBloc>(
          create: (BuildContext context) =>
              PalavrasBloc(palavraDAO: PalavraDAO())..add(PalavrasFetched()),
        ),
      ],
      child: MaterialApp(
        onGenerateRoute: AppRouter.generateRoute,
        debugShowCheckedModeBanner: false,
        title: 'Forca da UTFPR',
        theme: ThemeData(
          primarySwatch: Colors.blue,
          backgroundColor: Colors.green,
        ),
        home: const ForcaHomePage(),
      ),
    );
  }
}

class ForcaHomePage extends StatelessWidget {
  const ForcaHomePage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return const Scaffold(
      body: SplashScreenRoute(),
    );
  }
}
