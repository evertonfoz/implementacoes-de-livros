import 'package:capitulo03_splashscreen/routes/palavras/widgets/bottom_loader_widget.dart';
import 'package:capitulo03_splashscreen/routes/palavras/widgets/palavras_listtile_widget.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'bloc/palavras_list_bloc.dart';

class PalavrasListViewRoute extends StatefulWidget {
  const PalavrasListViewRoute({Key? key}) : super(key: key);

  @override
  _PalavrasListViewRouteState createState() => _PalavrasListViewRouteState();
}

class _PalavrasListViewRouteState extends State<PalavrasListViewRoute> {
  final _scrollController = ScrollController();
  final _scrollThreshold = 200.0;
  late final PalavrasBloc _palavrasListViewBloc;

  @override
  void initState() {
    super.initState();
    _palavrasListViewBloc = BlocProvider.of<PalavrasBloc>(context);
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
    _palavrasListViewBloc.add(PalavrasResetFetch());
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        centerTitle: true,
        title: const Text('Palavras registradas'),
        elevation: 10,
      ),
      body: BlocBuilder<PalavrasBloc, PalavrasLISTState>(
          builder: (context, formState) {
        if (formState.status == PalavrasStatus.failure) {
          return const Center(
            child: Text('Falha ao recuperar palavras'),
          );
        }

        if (formState.status == PalavrasStatus.success) {
          if (formState.palavras.isEmpty) {
            return const Center(
              child: Text('Nenhuma palavra registrada ainda'),
            );
          }

          return ListView.builder(
            controller: _scrollController,
            padding: const EdgeInsets.only(top: 10),
            itemCount: formState.hasReachedMax
                ? formState.palavras.length
                : formState.palavras.length + 1,
            itemBuilder: (BuildContext context, int index) {
              return (index >= formState.palavras.length)
                  ? const BottomLoaderWidget()
                  : PalavrasListTileWidget(
                      title: formState.palavras[index].palavra,
                      trailing: const Icon(Icons.keyboard_arrow_right),
                    );
            },
          );
        }

        return const Center(
          child: CircularProgressIndicator(),
        );
      }),
    );
  }

  onScroll(
      {required PalavrasBloc palavrasListViewBloc,
      required ScrollController scrollController,
      required double scrollThreshold}) {
    final maxScroll = scrollController.position.maxScrollExtent;
    final currentScroll = scrollController.position.pixels;
    if (maxScroll - currentScroll <= scrollThreshold) {
      palavrasListViewBloc.add(PalavrasFetched());
    }
  }
}
