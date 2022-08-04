import 'package:ec_delivery/features/boasvindas/data/datasources/boasvindas_datasource.dart';
import 'package:ec_delivery/features/produtos/presentation/components/crud/form.dart';
import 'package:ec_delivery/features/produtos/presentation/mobx_stores/produto_store.dart';
import 'package:ec_delivery/shared/functions/alertdialog.dart';
import 'package:flutter/material.dart';
import 'package:get_it/get_it.dart';

class ProdutosCRUDPage extends StatelessWidget {
  const ProdutosCRUDPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        leading: InkWell(
          child: const Icon(Icons.arrow_back),
          onTap: () => Navigator.of(context).pop(),
        ),
        title: InkWell(
          child: const Text('Dados do Produto'),
          onLongPress: () async {
            await BoasVindasDataSource.registerDontShowAgain(value: false);

            showDialogEC(
              context: context,
              title: 'Preferências resetadas',
              content:
                  'As preferências relacionadas à página de boas vindas, foram restauradas.',
            );
          },
        ),
      ),
      body: const SingleChildScrollView(
        child: Padding(
            padding: EdgeInsets.only(top: 28, left: 8, right: 8),
            child: ProdutosFormWidget()),
      ),
    );
  }
}
