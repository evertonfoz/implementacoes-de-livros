import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class InformationCupertinoAlertDialogWidget extends StatelessWidget {
  final String title;
  final String message;
  final List<Widget> actions;

  const InformationCupertinoAlertDialogWidget({
    @required this.title,
    @required this.message,
    @required this.actions,
  });

  @override
  Widget build(BuildContext context) {
    return CupertinoAlertDialog(
      title: Column(
        children: <Widget>[
          Text(this.title),
          SizedBox(
            height: 20,
          ),
        ],
      ),
      content: Text(this.message),
      actions: actions,
    );
  }
}
