import 'package:ec_delivery/features/produtos/data/datasources/produtos_sqlite_datasource.dart';
import 'package:ec_delivery/features/produtos/data/models/produto_model.dart';
import 'package:ec_delivery/features/produtos/domain/entities/produto.dart';
import 'package:ec_delivery/features/produtos/presentation/mobx_stores/produto_store.dart';
import 'package:ec_delivery/shared/presentation/components/snackbar/snackbar.dart';
import 'package:flutter/material.dart';
import 'package:flutter_mobx/flutter_mobx.dart';
import 'package:get_it/get_it.dart';

// ignore: must_be_immutable
class GravarProdutoButton extends StatelessWidget {
  GravarProdutoButton({Key? key}) : super(key: key);

  late BuildContext _context;

  @override
  Widget build(BuildContext context) {
    _context = context;

    return ConstrainedBox(
      constraints: BoxConstraints.tightFor(
        width: MediaQuery.of(context).size.width * 0.95,
        height: 45,
      ),
      child: Observer(
        builder: (_) {
          return ElevatedButton.icon(
            icon: const Icon(Icons.save),
            label: const Text(
              'Gravar',
              style: TextStyle(fontSize: 24),
            ),
            onPressed: !GetIt.I.get<ProdutoStore>().formOK ? null : _onPressed,
          );
        },
      ),
    );
  }

  _onPressed() async {
    var produto = ProdutoModel(
        produtoID: GetIt.I.get<ProdutoStore>().produtoID,
        nome: GetIt.I.get<ProdutoStore>().nome,
        descricao: GetIt.I.get<ProdutoStore>().descricao,
        valor: GetIt.I.get<ProdutoStore>().valor);

    await ProdutosSQLiteDatasource().save(produto);

    showBottomSnackBar(
      context: _context,
      title: 'Sucesso',
      content:
          'Os dados do produto ${produto.nome.toUpperCase()} foram registrados',
    );

    GetIt.I.get<ProdutoStore>().resetForm();
  }
}
