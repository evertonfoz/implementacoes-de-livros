import 'package:flutter/material.dart';

class GravarProdutoButton extends StatelessWidget {
  const GravarProdutoButton({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return ConstrainedBox(
      constraints: BoxConstraints.tightFor(
        width: MediaQuery.of(context).size.width * 0.95,
        height: 45,
      ),
      child: ElevatedButton.icon(
        icon: const Icon(Icons.save),
        label: const Text(
          'Gravar',
          style: TextStyle(fontSize: 24),
        ),
        onPressed: () {},
      ),
    );
  }
}
