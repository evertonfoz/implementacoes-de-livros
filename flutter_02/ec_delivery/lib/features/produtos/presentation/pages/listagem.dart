import 'package:ec_delivery/core/presentation/constants/urls.dart';
import 'package:ec_delivery/features/produtos/presentation/mobx_stores/produto_store.dart';
import 'package:ec_delivery/shared/presentation/components/circleavatar/circleavatar.dart';
import 'package:flutter/material.dart';
import 'package:get_it/get_it.dart';
import 'package:intl/intl.dart';

import '../../data/datasources/produtos_sqlite_datasource.dart';
import '../../data/models/produto_model.dart';
import 'crud.dart';

class ProdutosListPage extends StatelessWidget {
  const ProdutosListPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Produtos registrados'),
      ),
      body: Padding(
        padding: const EdgeInsets.only(top: 28),
        child: FutureBuilder(
            future: ProdutosSQLiteDatasource().getAll(),
            builder: (context, snapshot) {
              if (!snapshot.hasData) {
                return Center(
                    child: CircularProgressIndicator(
                  color: Colors.yellow.shade400,
                ));
              }
              return _listView(snapshot.data as List<ProdutoModel>);
            }),
      ),
    );
  }

  _listView(List<ProdutoModel> produtos) {
    return ListView.builder(
      itemCount: produtos.length,
      itemBuilder: (context, index) {
        ProdutoModel produto = produtos[index];
        return Padding(
          padding: const EdgeInsets.only(left: 8.0, right: 4.0),
          child: InkWell(
            onTap: () {
              GetIt.I.get<ProdutoStore>().inicializarForm(produtos[index]);

              Navigator.push(
                context,
                MaterialPageRoute(
                  builder: (context) => const ProdutosCRUDPage(),
                ),
              );
            },
            child: Padding(
              padding: const EdgeInsets.only(bottom: 8.0),
              child: _listTile(
                context,
                produtos[index],
              ),
            ),
          ),
        );
      },
    );
  }

  _valorEmMoedaCorrente(BuildContext context, double valor) {
    final formatadorValor =
        NumberFormat.simpleCurrency(locale: Intl.defaultLocale);
    return formatadorValor.format(
      valor,
    );
  }

  _listTile(BuildContext context, ProdutoModel produto) {
    return Row(
      children: [
        CircleAvatarPEF(
          imageURL: kTesteFotoURL,
          backgroundColor: Colors.indigo.shade900,
        ),
        const SizedBox(
          width: 8,
        ),
        Expanded(
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(
                produto.nome,
                style: const TextStyle(
                  color: Colors.white,
                  fontSize: 20,
                ),
              ),
              Text(
                produto.descricao,
                style: const TextStyle(
                  color: Colors.white54,
                  fontSize: 18,
                ),
              ),
            ],
          ),
        ),
        Text(
          '${_valorEmMoedaCorrente(context, produto.valor)}',
          style: TextStyle(
            color: Colors.yellow.shade500,
            fontSize: 20,
          ),
        ),
      ],
    );
  }
}
