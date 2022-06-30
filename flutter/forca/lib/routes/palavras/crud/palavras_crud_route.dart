import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:forca/models/palavra_model.dart';
import 'package:forca/widgets/container_iluminado_widget.dart';
import 'package:forca/widgets/dialogs/actions_textbutton_to_alertdialog_widget.dart';
import 'package:forca/widgets/dialogs/information_alert_dialog_widget.dart';
import 'package:forca/widgets/dialogs/success_dialog_widget.dart';
import 'package:forca/widgets/textbutton_with_snackbar_widget.dart';
import 'package:forca/widgets/textformfield_forca.dart';

import 'bloc/palavra_crud_bloc.dart';

class PalavrasCRUDRoute extends StatefulWidget {
  const PalavrasCRUDRoute({Key? key}) : super(key: key);

  @override
  State<PalavrasCRUDRoute> createState() => _PalavrasCRUDRouteState();
}

class _PalavrasCRUDRouteState extends State<PalavrasCRUDRoute> {
  final TextEditingController _palavraController = TextEditingController();
  final FocusNode _palavraFocus = FocusNode();
  PalavraModel _palavraModel = PalavraModel.empty();
  late BuildContext _buildContext;
  final TextEditingController _ajudaController = TextEditingController();
  final FocusNode _ajudaFocus = FocusNode();

  @override
  void initState() {
    super.initState();
    _palavraController.addListener(_onPalavraChanged);
    _ajudaController.addListener(_onAjudaChanged);
  }

  void _onPalavraChanged() {
    context.read<PalavraBloc>().add(
          ChangePalavra(
            palavraModel:
                _palavraModel.copyWith(palavra: _palavraController.text),
          ),
        );
  }

  void _onAjudaChanged() {
    context.read<PalavraBloc>().add(
          ChangeAjuda(
            palavraModel: _palavraModel.copyWith(ajuda: _ajudaController.text),
          ),
        );
  }

  void _onSubmitPressed() {
    context.read<PalavraBloc>().add(SubmitForm());
  }

  @override
  void dispose() {
    _palavraController.dispose();
    super.dispose();
  }

  Widget _form() {
    return Form(
      autovalidateMode: AutovalidateMode.onUserInteraction,
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.stretch,
        children: <Widget>[
          TextFormFieldForca(
            focusNode: _palavraFocus,
            controller: _palavraController,
            labelText: 'Palavra',
            textInputAction: TextInputAction.next,
            validator: (_) {
              return _palavraModel.palavra.isNotEmpty
                  ? null
                  : 'Informe a palavra';
            },
            onFieldSubmitted: (_) =>
                FocusScope.of(_buildContext).requestFocus(_ajudaFocus),
          ),
          const SizedBox(height: 20),
          TextFormFieldForca(
            maxLines: 5,
            focusNode: _ajudaFocus,
            controller: _ajudaController,
            labelText: 'Ajuda',
            validator: (_) {
              return _palavraModel.ajuda.isNotEmpty ? null : 'Informe a ajuda';
            },
            textInputAction: TextInputAction.done,
            onFieldSubmitted: (value) {},
          ),
          const SizedBox(
            height: 20,
          ),
          TextButtonWithSnackbarWidget(
            onPressedVisible: _palavraModel.isValid,
            buttonText: 'Gravar',
            successTextToSnackBar:
                'Os dados informados foram registrados com sucesso.',
            failTextToSnackBar: 'Erro na inserção',
            onButtonPressed: _onSubmitPressed,
            onSnackBarClosed: _resetForm,
          ),
        ],
      ),
    );
  }

  Widget _mainColumn() {
    return Column(
      children: <Widget>[
        Padding(
          padding: const EdgeInsets.symmetric(horizontal: 10.0, vertical: 10),
          child: ContainerIluminadoWidget(
            backgroundColor: Colors.white,
            shadowColor: Colors.white70,
            height: 350,
            child: Padding(
              padding: const EdgeInsets.only(left: 10, top: 10, right: 10),
              child: BlocBuilder<PalavraBloc, PalavraCRUDState>(
                  builder: (context, formState) {
                if (formState is PalavraChanged) {
                  _palavraModel = _palavraModel.copyWith(
                      palavra: formState.palavraModel.palavra);
                } else if (formState is AjudaChanged) {
                  _palavraModel = _palavraModel.copyWith(
                      ajuda: formState.palavraModel.ajuda);
                } else if (formState is FormIsSubmitted) {
                  return SuccessDialogWidget(
                    onDismissed: () {
                      _palavraController.clear();
                      _ajudaController.clear();
                    },
                  );
                }
                return _form();
              }),
            ),
          ),
        ),
        const SizedBox(
          height: 10,
        ),
      ],
    );
  }

  _successDialog() async {
    await showDialog(
      barrierDismissible: false,
      context: context,
      builder: (BuildContext context) {
        return const InformationAlertDialogWidget(
          title: 'Tudo certo',
          message: 'Os dados informados foram registrados com sucesso.',
          actions: [
            ActionsTextButtonToAlertDialogWidget(
              messageButton: 'OK',
              isDefaultAction: true,
            ),
          ],
        );
      },
    );
  }

  _resetForm() {
    _palavraController.clear();
    _ajudaController.clear();
  }

  @override
  Widget build(BuildContext context) {
    _buildContext = context;
    return Scaffold(
      backgroundColor: Colors.grey[400],
      appBar: AppBar(
        backgroundColor: Colors.grey[600],
        title: const Text(
          'Registro de Palavras',
        ),
      ),
      body: SafeArea(
        child: Center(
          child: SingleChildScrollView(
            child: _mainColumn(),
          ),
        ),
      ),
    );
  }
}
