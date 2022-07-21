import 'package:ec_delivery/features/produtos/presentation/components/crud/form.dart';
import 'package:flutter/material.dart';

class ProdutosCRUDPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Dados do Produto')),
      body: const SingleChildScrollView(
        child: Padding(
            padding: EdgeInsets.only(top: 28, left: 8, right: 8),
            child: ProdutosFormWidget()),
      ),
    );
  }
}
