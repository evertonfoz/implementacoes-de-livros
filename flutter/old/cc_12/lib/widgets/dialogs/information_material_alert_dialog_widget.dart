import 'package:flutter/material.dart';

class InformationMaterialAlertDialogWidget extends StatelessWidget {
  final String title;
  final String message;
  final List<Widget> actions;

  const InformationMaterialAlertDialogWidget({
    @required this.title,
    @required this.message,
    @required this.actions,
  });

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: Column(
        children: <Widget>[
          Text(this.title),
          SizedBox(
            height: 20,
          ),
        ],
      ),
      content: Text(
        this.message,
      ),
      actions: actions,
    );
  }
}
