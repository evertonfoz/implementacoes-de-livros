import 'package:capitulo03_splashscreen/models/palavra_model.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../mixins/widgets_mixin.dart';
import '../widgets/container_iluminado_widget.dart';
import 'palavras/bloc/palavras_blocs.dart';

class PalavrasCRUDRoute extends StatefulWidget {
  const PalavrasCRUDRoute({Key? key}) : super(key: key);

  @override
  _PalavrasCRUDRouteState createState() => _PalavrasCRUDRouteState();
}

class _PalavrasCRUDRouteState extends State<PalavrasCRUDRoute>
    with TextFormFieldMixin {
  final _palavraController = TextEditingController();
  final _ajudaController = TextEditingController();
  final FocusNode _palavraFocus = FocusNode();
  final FocusNode _ajudaFocus = FocusNode();

// PalavrasCrudFormBloc _palavrasCrudFormBloc;
  late BuildContext _buildContext;

  @override
  void initState() {
    super.initState();
    // this._palavrasCrudFormBloc = BlocProvider.of<PalavrasCrudFormBloc>(context);
    _palavraController.addListener(_onPalavraChanged);
    // _ajudaController.addListener(_onAjudaChanged);
  }

  @override
  void dispose() {
    _palavraController.dispose();
    _ajudaController.dispose();
    super.dispose();
  }

  void _onPalavraChanged() {
    context.read<PalavraBloc>().add(PalavraChanged());
    // _palavrasCrudFormBloc.add(PalavraChanged(palavra: this._palavraController.text));
  }

// void _onAjudaChanged() {
//     _palavrasCrudFormBloc.add(AjudaChanged(ajuda: this._ajudaController.text));
// }

  Widget _form() {
    return Form(
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.stretch,
        children: <Widget>[
          textFormField(
              focusNode: _palavraFocus,
              controller: _palavraController,
              labelText: 'Palavra',
              onFieldSubmitted: (_) =>
                  FocusScope.of(_buildContext).requestFocus(_ajudaFocus),
              textInputAction: TextInputAction.next,
              validator: (_) {
                // return formState.aPalavraEhValida ? null : 'Informe a palavra';
              }),
          const SizedBox(
            height: 20,
          ),
          textFormField(
              maxLines: 5,
              focusNode: this._ajudaFocus,
              controller: this._ajudaController,
              labelText: 'Ajuda',
              validator: (_) {
                // return formState.aAjudaEhValida ? null : 'Informe a ajuda';
              }),
          const SizedBox(
            height: 20,
          ),
          const TextButton(
            onPressed: null, // formState.isFormValid ? _onSubmitPressed : null,
            child: Text('Gravar'),
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
              child: BlocBuilder<PalavraBloc, PalavraModel>(
                  builder: (context, formState) {
                return _form(formState);
              }),
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
            child: Container(),
          ),
        ),
      ),
    );
  }
}
