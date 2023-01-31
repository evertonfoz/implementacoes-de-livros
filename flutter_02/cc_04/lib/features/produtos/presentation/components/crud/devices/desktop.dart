import 'package:ec_delivery/features/produtos/presentation/components/crud/button.dart';
import 'package:ec_delivery/features/produtos/presentation/components/crud/photo.dart';
import 'package:ec_delivery/features/produtos/presentation/components/crud/textfields.dart';
import 'package:flutter/material.dart';

class DesktopForm extends StatelessWidget {
  const DesktopForm({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        Row(
          children: const [
            Expanded(flex: 2, child: FormTextFields()),
            Expanded(child: PhotoProdutoWidget()),
          ],
        ),
        const SizedBox(height: 20),
        GravarProdutoButton(),
      ],
    );
  }
}
