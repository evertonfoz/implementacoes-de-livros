import 'package:ec_delivery/features/produtos/presentation/components/crud/button.dart';
import 'package:ec_delivery/features/produtos/presentation/components/crud/photo.dart';
import 'package:ec_delivery/features/produtos/presentation/components/crud/textfields.dart';
import 'package:flutter/material.dart';

class MobileForm extends StatelessWidget {
  const MobileForm({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        const Expanded(flex: 4, child: FormTextFields()),
        const Expanded(flex: 4, child: PhotoProdutoWidget()),
        const SizedBox(height: 10),
        Expanded(flex: 1, child: GravarProdutoButton()),
      ],
    );
  }
}
