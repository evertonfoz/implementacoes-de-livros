import 'package:capitulo03_splashscreen/routes/palavras/crud/bloc/palavra_crud_bloc.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'bloc/palavras_list_bloc.dart';

class PalavrasListViewRoute extends StatefulWidget {
  const PalavrasListViewRoute({Key? key}) : super(key: key);

  @override
  _PalavrasListViewRouteState createState() => _PalavrasListViewRouteState();
}

class _PalavrasListViewRouteState extends State<PalavrasListViewRoute> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        centerTitle: true,
        title: Text('Palavras registradas'),
        elevation: 10,
      ),
      body: BlocBuilder<PalavrasBloc, PalavrasLISTState>(
          builder: (context, formState) {
        return Container();
      }),
    );
  }
}
