import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'bloc/listview/palavras_listview_bloc.dart';
import 'mixin/palavras_listview_mixin.dart';
import 'widgets/palavras_listtile_widget.dart';

class PalavrasListViewRoute extends StatefulWidget {
  @override
  _PalavrasListViewRouteState createState() => _PalavrasListViewRouteState();
}

class _PalavrasListViewRouteState extends State<PalavrasListViewRoute>
    with PalavrasListViewMixim {
  final _scrollController = ScrollController();
  final _scrollThreshold = 200.0;
  PalavrasListViewBloc _palavrasListViewBloc;

  @override
  void initState() {
    super.initState();
    _scrollController.addListener(onScroll);
    _palavrasListViewBloc = BlocProvider.of<PalavrasListViewBloc>(context);
  }

  @override
  void dispose() {
    _scrollController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        centerTitle: true,
        title: Text('Palavras registradas'),
        elevation: 10,
      ),
      body: BlocBuilder<PalavrasListViewBloc, PalavrasListViewBlocState>(
          builder: (context, state) {
        if (state is PalavrasListViewBlocError) {
          return centerText(
              text: 'Falha ao recuperar palavras: ${state.errorMessage}');
        }

        if (state is PalavrasListViewLoaded) {
          if (state.palavras.isEmpty) {
            return centerText(text: 'Nenhuma palavra registrada ainda.');
          }

          return ListView.builder(
            controller: _scrollController,
            padding: EdgeInsets.only(top: 10),
            itemCount: state.palavras.length,
            itemBuilder: (BuildContext context, int index) {
              return PalavrasListTileWidget(
                title: state.palavras[index].palavra,
                trailing: Icon(Icons.keyboard_arrow_right),
              );
            },
          );
        }

        return Center(
          child: CircularProgressIndicator(),
        );
      }),
    );
  }
}
