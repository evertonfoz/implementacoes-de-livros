import 'dart:io';
import 'package:flutter/material.dart';
import 'information_cupertino_alert_dialog_widget.dart';
import 'information_material_alert_dialog_widget.dart';

class InformationAlertDialogWidget extends StatelessWidget {
  final String title;
  final String message;
  final List<Widget> actions;

  const InformationAlertDialogWidget({
    Key? key,
    required this.title,
    required this.message,
    required this.actions,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return (Platform.isAndroid)
        ? InformationMaterialAlertDialogWidget(
            title: title,
            message: message,
            actions: actions,
          )
        : InformationCupertinoAlertDialogWidget(
            title: title,
            message: message,
            actions: actions,
          );
  }
}
