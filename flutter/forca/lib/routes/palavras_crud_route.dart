import 'package:capitulo03_splashscreen/models/palavra_model.dart';
import 'package:capitulo03_splashscreen/routes/palavras/crud/bloc/palavra_crud_bloc.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../mixins/widgets_mixin.dart';
import '../widgets/container_iluminado_widget.dart';
import 'palavras/crud/view_models/palavra_viewmodel.dart';

class PalavrasCRUDRoute extends StatefulWidget {
  const PalavrasCRUDRoute({Key? key}) : super(key: key);

  @override
  _PalavrasCRUDRouteState createState() => _PalavrasCRUDRouteState();
}

class _PalavrasCRUDRouteState extends State<PalavrasCRUDRoute>
    with TextFormFieldMixin {
  final TextEditingController _palavraController = TextEditingController();
  // final TextEditingController _ajudaController = TextEditingController();
  final FocusNode _palavraFocus = FocusNode();
  // final FocusNode _ajudaFocus = FocusNode();

  final PalavraModel _palavraModel = PalavraModel.empty();

  late BuildContext _buildContext;

  @override
  void initState() {
    super.initState();
    _palavraController.addListener(_onPalavraChanged);
    // _ajudaController.addListener(_onAjudaChanged);
  }

  @override
  void dispose() {
    _palavraController.dispose();
    // _ajudaController.dispose();
    super.dispose();
  }

  void _onPalavraChanged() {
    context.read<PalavraBloc>().add(
          ChangePalavra(
            palavraModel:
                _palavraModel.copyWith(palavra: _palavraController.text),
          ),
        );
  }

  // void _onAjudaChanged() {
  //   context.read<PalavraBloc>().add(AjudaChanged());
  // }

  // void _onSubmitPressed() {
  //   context.read<PalavraBloc>().add(PalavraFormSuccessSubmitted());
  // }

  Widget _form() {
    return Form(
      autovalidateMode: AutovalidateMode.onUserInteraction,
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.stretch,
        children: <Widget>[
          textFormField(
              focusNode: _palavraFocus,
              controller: _palavraController,
              labelText: 'Palavra',
              // onFieldSubmitted: (_) =>
              //     FocusScope.of(_buildContext).requestFocus(_ajudaFocus),
              textInputAction: TextInputAction.next,
              validator: (_) {
                return _palavraModel.palavra.isNotEmpty
                    ? null
                    : 'Informe a palavra';
              }),
          // const SizedBox(
          //   height: 20,
          // ),
          // textFormField(
          //     maxLines: 5,
          //     focusNode: _ajudaFocus,
          //     controller: _ajudaController,
          //     labelText: 'Ajuda',
          //     validator: (_) {
          //       // return palavraModel != null && palavraModel.ajuda.isNotEmpty
          //       //     ? null
          //       //     : 'Informe a ajuda';
          //     }),
          // const SizedBox(
          //   height: 20,
          // ),
          // TextButton(
          //   onPressed: palavraModel != null &&
          //           palavraModel.palavra.isNotEmpty &&
          //           palavraModel.ajuda.isNotEmpty
          //       ? _onSubmitPressed
          //       : null,
          //   child: const Text('Gravar'),
          // ),
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
                  builder: (context, state) {
                    if (state is PalavraChanged) {
                      _palavraModel.copyWith( (state as PalavraChanged).palavraModel;
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
