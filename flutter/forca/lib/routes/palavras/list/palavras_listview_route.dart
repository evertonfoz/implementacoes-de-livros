import 'package:dialog_information_to_specific_platform/dialog_information_to_specific_platform.dart';
import 'package:dialog_information_to_specific_platform/flat_buttons/actions_flatbutton_to_alert_dialog.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:forca/local_persistence/daos/palavra_dao.dart';
import 'package:forca/routes/palavras/list/bloc/palavras_list_bloc.dart';
import 'package:forca/routes/palavras/widgets/bottom_loader_widget.dart';
import 'package:forca/routes/palavras/widgets/palavras_listtile_widget.dart';

class PalavrasListViewRoute extends StatefulWidget {
  const PalavrasListViewRoute({Key? key}) : super(key: key);

  @override
  _PalavrasListViewRouteState createState() => _PalavrasListViewRouteState();
}

class _PalavrasListViewRouteState extends State<PalavrasListViewRoute> {
  late final PalavrasBloc _palavrasListViewBloc;
  final _scrollController = ScrollController();
  final _scrollThreshold = 200.0;

  @override
  void initState() {
    super.initState();
    _palavrasListViewBloc = BlocProvider.of<PalavrasBloc>(context);
    _scrollController.addListener(
      () => _onScroll(
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
                  : Dismissible(
                      key: Key(formState.palavras[index].palavraID!),
                      confirmDismiss: (direction) async {
                        var oQueFazer = await confirmDismiss(
                            context: context,
                            palavra: formState.palavras[index].palavra,
                            palavraID: formState.palavras[index].palavraID!);
                        return oQueFazer == 'Sim';
                      },
                      onDismissed: (direction) async {
                        await dismissedComplete(
                            context: context,
                            palavraID: formState.palavras[index].palavraID!,
                            palavra: formState.palavras[index].palavra);
                        return;
                      },
                      background: Container(
                        color: Colors.red,
                      ),
                      child: PalavrasListTileWidget(
                        title: formState.palavras[index].palavra,
                        trailing: const Icon(Icons.keyboard_arrow_right),
                      ),
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

  _onScroll(
      {required PalavrasBloc palavrasListViewBloc,
      required ScrollController scrollController,
      required double scrollThreshold}) {
    final maxScroll = scrollController.position.maxScrollExtent;
    final currentScroll = scrollController.position.pixels;
    if (maxScroll - currentScroll <= scrollThreshold) {
      palavrasListViewBloc.add(PalavrasFetched());
    }
  }

  Future<bool> confirmDismiss({
    required BuildContext context,
    required String palavra,
    required String palavraID,
  }) async {
    String oQueFazer = await showDialog(
      barrierDismissible: false,
      context: context,
      builder: (BuildContext context) {
        return InformationAlertDialog(
          iconTitle: const Icon(
            Icons.message,
            color: Colors.red,
          ),
          title: 'Oops...Quer remover?',
          message: 'Confirma a remoção da palavra ${palavra.toUpperCase()}',
          buttons: [
            ActionsFlatButtonToAlertDialog(
              messageButton: 'Não',
              isEnabled: true,
            ),
            //   InformationAlertDialog.createFlatButton(),
            ActionsFlatButtonToAlertDialog(
              messageButton: 'Sim',
              isEnabled: true,
            ),
            //   InformationAlertDialog.createFlatButton(),
          ],
        );
      },
    );

    if (oQueFazer == 'Não') return false;

    return await _removePalavra(palavraID, context, palavra);
  }

  Future<void> dismissedComplete(
      {required BuildContext context,
      required String palavraID,
      required String palavra}) async {
    ScaffoldMessenger.of(context).showSnackBar(
      SnackBar(
        backgroundColor: Colors.indigo,
        content: Text(
          'Palavra ${palavra.toUpperCase()} foi removida',
        ),
      ),
    );
  }

  Future<bool> _removePalavra(
      String palavraID, BuildContext context, String palavra) async {
    try {
      PalavraDAO palavraDAO = PalavraDAO();
      await palavraDAO.deleteByID(palavraID);
      return true;
    } catch (exception) {
      _showSnackBarMessage(
          context: context,
          message:
              'Erro ao remover a Palavra ${palavra.toUpperCase()}: $exception',
          backgroundColor: Colors.red);
      return false;
    }
  }

  Future _showSnackBarMessage(
      {required BuildContext context,
      required String message,
      required Color backgroundColor}) async {
    ScaffoldMessenger.of(context)
        .showSnackBar(SnackBar(
          backgroundColor: backgroundColor,
          content: Text(
            message,
          ),
        ))
        .closed
        .then((_) {
      return;
    });
  }
}
