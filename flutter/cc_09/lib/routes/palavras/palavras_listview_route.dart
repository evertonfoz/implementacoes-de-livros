import 'dart:async';

import 'package:cc04/app_constants/router_constants.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'bloc/listview/palavras_listview_bloc.dart';
import 'mixin/palavras_listview_mixin.dart';
import 'widgets/bottom_loader_widget.dart';
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
    _palavrasListViewBloc = BlocProvider.of<PalavrasListViewBloc>(context)
      ..add(PalavrasListViewBlocEventFetch());
    _scrollController.addListener(
      () => onScroll(
          palavrasListViewBloc: _palavrasListViewBloc,
          scrollController: _scrollController,
          scrollThreshold: _scrollThreshold),
    );
  }

  @override
  void dispose() {
    _scrollController.dispose();
    _palavrasListViewBloc.add(PalavrasListViewBlocEventResetFetch());
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
            itemCount: state.hasReachedMax
                ? state.palavras.length
                : state.palavras.length + 1,
            itemBuilder: (BuildContext context, int index) {
              return (index >= state.palavras.length)
                  ? BottomLoaderWidget()
                  : Dismissible(
                      key: Key(state.palavras[index].palavraID),
                      confirmDismiss: (direction) async {
                        return await confirmDismiss(
                            context: context,
                            palavra: state.palavras[index].palavra,
                            palavraID: state.palavras[index].palavraID);
                      },
                      onDismissed: (direction) async {
                        await dismissedComplete(
                            context: context,
                            palavraID: state.palavras[index].palavraID,
                            palavra: state.palavras[index].palavra);

                        _palavrasListViewBloc.add(
                          PalavrasListViewBlocEventConfirmDismiss(
                              indexOfDismissible: index),
                        );
                      },
                      background: Container(
                        color: Colors.red,
                      ),
                      child: InkWell(
                        onLongPress: () async {
                          _palavrasListViewBloc
                              .add(PalavrasListViewBlocEventResetFetch());

                          await Navigator.of(context).pushNamed(
                              kPalavrasCRUDRoute,
                              arguments: state.palavras[index]);

                          _palavrasListViewBloc =
                              BlocProvider.of<PalavrasListViewBloc>(context)
                                ..add(PalavrasListViewBlocEventFetch());
//                          Timer(Duration(seconds: 5), () => print('ok'));
//                          _palavrasListViewBloc
//                              .add(PalavrasListViewBlocEventFetch());
//                          Timer(Duration(seconds: 5), () => print('ok'));
                        },
                        child: PalavrasListTileWidget(
                          title: state.palavras[index].palavra,
                          trailing: Icon(Icons.keyboard_arrow_right),
                        ),
                      ),
                    );
            },
          );
        }

        if (state is PalavrasListViewBlocUninitialized)
          _palavrasListViewBloc.add(PalavrasListViewBlocEventFetch());

        return Center(
          child: CircularProgressIndicator(),
        );
      }),
    );
  }
}
