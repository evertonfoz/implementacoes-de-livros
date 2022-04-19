import 'dart:io';

import 'package:capitulo03_splashscreen/models/palavra_model.dart';
import 'package:capitulo03_splashscreen/routes/palavras/crud/bloc/palavra_crud_bloc.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../mixins/widgets_mixin.dart';
import '../widgets/container_iluminado_widget.dart';
import '../widgets/textbutton_with_snackbar_widget.dart';

class PalavrasCRUDRoute extends StatefulWidget {
  const PalavrasCRUDRoute({Key? key}) : super(key: key);

  @override
  _PalavrasCRUDRouteState createState() => _PalavrasCRUDRouteState();
}

class _PalavrasCRUDRouteState extends State<PalavrasCRUDRoute>
    with TextFormFieldMixin {
  final TextEditingController _palavraController = TextEditingController();
  final TextEditingController _ajudaController = TextEditingController();
  final FocusNode _palavraFocus = FocusNode();
  final FocusNode _ajudaFocus = FocusNode();

  PalavraModel _palavraModel = PalavraModel.empty();

  late BuildContext _buildContext;

  @override
  void initState() {
    super.initState();
    _palavraController.addListener(() {
      if (_palavraController.text.isEmpty) {
        if (!mounted) return;
        setState(() {});
      }
    });
    // _palavraController.addListener(_onPalavraChanged);
    // _ajudaController.addListener(_onAjudaChanged);
  }

  @override
  void dispose() {
    _palavraController.dispose();
    _ajudaController.dispose();
    super.dispose();
  }

  void _onPalavraChanged(String value) {
    context.read<PalavraBloc>().add(
          ChangePalavra(
            palavraModel: _palavraModel.copyWith(palavra: value),
          ),
        );
  }

  void _onAjudaChanged(String value) {
    context.read<PalavraBloc>().add(
          ChangeAjuda(
            palavraModel: _palavraModel.copyWith(ajuda: value),
          ),
        );
  }

  void _onSubmitPressed() {
    context.read<PalavraBloc>().add(SubmitForm(palavraModel: _palavraModel));
  }

  Widget _form() {
    return Form(
      autovalidateMode: AutovalidateMode.onUserInteraction,
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.stretch,
        children: <Widget>[
          textFormField(
            initialValue: _palavraModel.palavra,
            focusNode: _palavraFocus,
            controller: _palavraController,
            labelText: 'Palavra',
            onFieldSubmitted: (_) =>
                FocusScope.of(_buildContext).requestFocus(_ajudaFocus),
            textInputAction: TextInputAction.next,
            validator: (_) {
              return _palavraModel.palavra.isNotEmpty
                  ? null
                  : 'Informe a palavra';
            },
            onChanged: (value) => _onPalavraChanged(value),
          ),
          const SizedBox(height: 20),
          textFormField(
            initialValue: _palavraModel.ajuda,
            maxLines: 5,
            focusNode: _ajudaFocus,
            controller: _ajudaController,
            labelText: 'Ajuda',
            validator: (_) {
              return _palavraModel.ajuda.isNotEmpty ? null : 'Informe a ajuda';
            },
            onChanged: (value) => _onAjudaChanged(value),
          ),
          const SizedBox(
            height: 20,
          ),
          TextButtonWithSnackbarWidget(
            onPressedVisible: _palavraModel.isValid,
            buttonText: 'Gravar',
            textToSnackBar:
                'Os dados informados foram registrados com sucesso.',
            onButtonPressed: _onSubmitPressed,
            // onStackBarClosed: _resetForm,
          ),

          // TextButton(
          //   onPressed: _palavraModel.isValid
          //       ? () async {
          //           _onSubmitPressed();
          //           await _successDialog();
          //           _resetForm();
          //         }
          //       : null,
          //   child: const Text('Gravar'),
          // ),
        ],
      ),
    );
  }

  // _successDialog() async {
  //   await showDialog(
  //     barrierDismissible: false,
  //     context: context,
  //     builder: (BuildContext context) {
  //       return const InformationAlertDialogWidget(
  //         title: 'Tudo certo',
  //         message: 'Os dados informados foram registrados com sucesso.',
  //         actions: [
  //           ActionsFlatButtonToAlertDialogWidget(
  //             messageButton: 'OK',
  //             isDefaultAction: true,
  //           ),
  //         ],
  //       );
  //     },
  //   );
  // }

  _resetForm() {
    _palavraModel = PalavraModel.empty();
    _ajudaController.text = _palavraModel.ajuda;
    _palavraController.clear();
    context.read<PalavraBloc>().add(ResetForm(palavraModel: _palavraModel));
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
                  builder: (context, state) {
                if (state is PalavraChanged) {
                  _palavraModel = _palavraModel.copyWith(
                      palavra: state.palavraModel.palavra);
                } else if (state is AjudaChanged) {
                  _palavraModel =
                      _palavraModel.copyWith(ajuda: state.palavraModel.ajuda);
                } else if (state is FormIsSubmitted) {
                  // _palavraModel = PalavraModel.empty();
                  // state.palavraModel;
                  _resetForm();
                } else if (state is FormIsReseted) {
                  _palavraModel = state.palavraModel;
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
