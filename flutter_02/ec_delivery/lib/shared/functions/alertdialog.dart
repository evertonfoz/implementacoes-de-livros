import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

showDialogEC({
  required BuildContext context,
  required String title,
  required String content,
}) {
  showDialog<void>(
    context: context,
    barrierDismissible: false,
    builder: (BuildContext context) {
      return AlertDialog(
        title: Text(title),
        content: Text(
          content,
          style: const TextStyle(
            color: Colors.black,
          ),
        ),
        actions: <Widget>[
          TextButton(
            child: const Text('OK'),
            onPressed: () {
              Navigator.of(context).pop();
            },
          ),
        ],
      );
    },
  );
}
