import 'dart:async';

import 'package:cc04/local_persistence/daos/palavra_dao.dart';
import 'package:cc04/mixins/widgets_mixin.dart';
import 'package:cc04/widgets/container_iluminado_widget.dart';
import 'package:cc04/widgets/dialogs/actions_flatbutton_to_alertdialog_widget.dart';
import 'package:cc04/widgets/dialogs/information_alert_dialog_widget.dart';
import 'package:cc04/widgets/raisedbutton_with_snackbar_widget.dart';
import 'package:cc04/models/palavra_model.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'bloc/crud/palavras_crud_form_bloc.dart';
import 'bloc/crud/palavras_crud_form_event.dart';
import 'bloc/crud/palavras_crud_form_state.dart';
import 'bloc/listview/palavras_listview_bloc.dart';
import 'mixin/palavras_crud_mixin.dart';

class PalavrasCRUDRoute extends StatefulWidget {
  final PalavraModel palavraModel;

  const PalavrasCRUDRoute({this.palavraModel});

  @override
  _PalavrasCRUDRouteState createState() => _PalavrasCRUDRouteState();
}

class _PalavrasCRUDRouteState extends State<PalavrasCRUDRoute>
    with TextFormFieldMixin, PalavrasCRUDMixin {
  final _palavraController = TextEditingController();
  final _ajudaController = TextEditingController();
  final FocusNode _palavraFocus = FocusNode();
  final FocusNode _ajudaFocus = FocusNode();

  PalavrasCrudFormBloc _palavrasCrudFormBloc;
  BuildContext _buildContext;

  @override
  void initState() {
    super.initState();
    this._palavrasCrudFormBloc = BlocProvider.of<PalavrasCrudFormBloc>(context);
    this._palavraController.addListener(_onPalavraChanged);
    this._ajudaController.addListener(_onAjudaChanged);
    if (widget.palavraModel != null) {
      _initializeTextControllers();
    }
  }

  @override
  void dispose() {
    this._palavraController.dispose();
    this._ajudaController.dispose();
    super.dispose();
  }

  void _onPalavraChanged() {
    _palavrasCrudFormBloc
        .add(PalavraChanged(palavra: this._palavraController.text));
  }

  void _onAjudaChanged() {
    _palavrasCrudFormBloc.add(AjudaChanged(ajuda: this._ajudaController.text));
  }

  Widget _form(PalavrasCrudFormState formState) {
    return Form(
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.stretch,
        children: <Widget>[
          textFormField(
              focusNode: this._palavraFocus,
              controller: this._palavraController,
              labelText: 'Palavra',
              onFieldSubmitted: (_) => FocusScope.of(this._buildContext)
                  .requestFocus(this._ajudaFocus),
              textInputAction: TextInputAction.next,
              validator: (_) {
                return formState.aPalavraEhValida ? null : 'Informe a palavra';
              }),
          SizedBox(
            height: 20,
          ),
          textFormField(
              maxLines: 5,
              focusNode: this._ajudaFocus,
              controller: this._ajudaController,
              labelText: 'Ajuda',
              validator: (_) {
                return formState.aAjudaEhValida ? null : 'Informe a ajuda';
              }),
          SizedBox(
            height: 20,
          ),
          Row(
            mainAxisAlignment: MainAxisAlignment.end,
            children: <Widget>[
              RaisedButton(
                onPressed:
                    formState.isFormValid ? _restoreOriginalDataToTexts : null,
                child: Text('Cancelar'),
              ),
              SizedBox(
                width: 20,
              ),
              RaisedButtonWithSnackbarWidget(
                onPressedVisible: formState.isFormValid,
                buttonText: 'Gravar',
                successTextToSnackBar:
                    'Os dados informados foram registrados com sucesso.',
                failTextToSnackBar: 'Erro na inserção',
                onButtonPressed: _onSubmitPressed,
                onStackBarClosed: _resetForm,
              ),
            ],
          ),
        ],
      ),
    );
  }

  void _onSubmitPressed() async {
    PalavraDAO palavraDAO = PalavraDAO();
    PalavraModel palavraModel = PalavraModel(
        palavraID: (widget.palavraModel == null)
            ? null
            : widget.palavraModel.palavraID,
        palavra: this._palavraController.text,
        ajuda: this._ajudaController.text);

    try {
      await palavraDAO.update(palavraModel: palavraModel);
      _palavrasCrudFormBloc.add(FormSuccessSubmitted());
    } catch (e) {
      rethrow;
    }
  }

  Widget _mainColumn() {
    return Column(
      children: <Widget>[
        Container(
          child: Padding(
            padding: const EdgeInsets.symmetric(horizontal: 10.0, vertical: 10),
            child: ContainerIluminadoWidget(
              backgroundColor: Colors.white,
              shadowColor: Colors.white70,
              height: 350,
              child: Padding(
                padding: const EdgeInsets.only(left: 10, top: 10, right: 10),
                child: BlocBuilder<PalavrasCrudFormBloc, PalavrasCrudFormState>(
                    builder: (context, formState) {
                  if (formState.formularioEnviadoComSucesso) {
                    Timer(Duration(seconds: 4), () {
                      _palavraController.clear();
                      _ajudaController.clear();
                      this._palavrasCrudFormBloc.add(FormReset());
                    });
                  }
                  return _form(formState);
                }),
              ),
            ),
          ),
        ),
        SizedBox(
          height: 10,
        ),
      ],
    );
  }

  @override
  Widget build(BuildContext context) {
    this._buildContext = context;
    return WillPopScope(
      onWillPop: () async => await onWillPop(
  context: context,
  palavraModel: widget.palavraModel,
  palavra: _palavraController.text,
  ajuda: _ajudaController.text),
      child: Scaffold(
        backgroundColor: Colors.grey[400],
        appBar: AppBar(
          backgroundColor: Colors.grey[600],
          title: Text(
            widget.palavraModel == null
                ? 'Registro de Palavras'
                : 'Alteração de uma palavra',
          ),
        ),
        body: SafeArea(
          child: Center(
            child: SingleChildScrollView(
              child: _mainColumn(),
            ),
          ),
        ),
      ),
    );
  }

  _resetForm() {
    _clearTexts();
    if (widget.palavraModel != null)
      Navigator.of(context).pop();
    else
      this._palavrasCrudFormBloc.add(FormReset());
  }

  _initializeTextControllers() {
    this._palavraController.text = widget.palavraModel.palavra;
    this._ajudaController.text = widget.palavraModel.ajuda;
  }

  _clearTexts() {
    _palavraController.clear();
    _ajudaController.clear();
  }

  _restoreOriginalDataToTexts() {
    if (widget.palavraModel == null) {
      _clearTexts();
    } else {
      _palavraController.text = widget.palavraModel.palavra;
      _ajudaController.text = widget.palavraModel.ajuda;
    }
  }
}
