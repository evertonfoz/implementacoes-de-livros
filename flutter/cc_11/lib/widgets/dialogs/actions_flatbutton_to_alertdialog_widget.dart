import 'dart:io';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class ActionsFlatButtonToAlertDialogWidget extends StatelessWidget {
  final String messageButton;
  final bool isDefaultAction;
  final bool isDestructiveAction;

  const ActionsFlatButtonToAlertDialogWidget({
    @required this.messageButton,
    this.isDefaultAction = false,
    this.isDestructiveAction = false,
  });

  @override
  Widget build(BuildContext context) {
    return (Platform.isAndroid)
        ? FlatButton(
            onPressed: () => Navigator.of(context).pop(this.messageButton),
            child: Text(
              this.messageButton,
            ),
          )
        : CupertinoDialogAction(
            isDefaultAction: this.isDestructiveAction,
            isDestructiveAction: this.isDestructiveAction,
            child: Text(this.messageButton),
            onPressed: () => Navigator.of(context).pop(this.messageButton),
          );
  }
}
