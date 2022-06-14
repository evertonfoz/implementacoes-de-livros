import 'package:flutter/material.dart';

class BottomLoaderWidget extends StatelessWidget {
  const BottomLoaderWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      color: Colors.indigo,
      width: double.maxFinite,
      height: 250,
      child: const Padding(
        padding: EdgeInsets.symmetric(vertical: 10),
        child: Center(
          child: Text(
            'Carregando mais registros',
            textAlign: TextAlign.center,
            style: TextStyle(
              color: Colors.white,
              fontSize: 25,
            ),
          ),
        ),
      ),
    );
  }
}
