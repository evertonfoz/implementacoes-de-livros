import 'package:flutter/material.dart';

class InformationMaterialAlertDialogWidget extends StatelessWidget {
  final String title;
  final String message;
  final List<Widget> actions;

  const InformationMaterialAlertDialogWidget({
    Key? key,
    required this.title,
    required this.message,
    required this.actions,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: Column(
        children: <Widget>[
          Text(title),
          const SizedBox(
            height: 20,
          ),
        ],
      ),
      content: Text(
        message,
      ),
      actions: actions,
    );
  }
}