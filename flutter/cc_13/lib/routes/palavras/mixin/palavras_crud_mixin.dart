import 'package:cc04/models/palavra_model.dart';
import 'package:dialog_information_to_specific_platform/dialog_information_to_specific_platform.dart';
import 'package:dialog_information_to_specific_platform/flat_buttons/actions_flatbutton_to_alert_dialog.dart';
import 'package:flutter/material.dart';

mixin PalavrasCRUDMixin {
  Future<bool> onWillPop({BuildContext context, PalavraModel palavraModel, String palavra, String ajuda}) async {
    if (palavraModel == null) {
      if (palavra.isEmpty && ajuda.isEmpty) return true;
    }

    if (palavraModel != null) {
      if (palavraModel.palavra == palavra && palavraModel.ajuda == ajuda)
        return true;
      if (palavra.isEmpty && ajuda.isEmpty) return true;
    }

    String oQueFazer = await showDialog(
      barrierDismissible: false,
      context: context,
      child: InformationAlertDialog(
        iconTitle: Icon(
          Icons.error,
          color: Colors.red,
        ),
        title: 'Quer sair?',
        message: 'Olha, os dados foram alterados, você vai descartá-los?',
        buttons: [
          ActionsFlatButtonToAlertDialog(
            messageButton: 'Não',
            isEnabled: true,
          ),
          //   InformationAlertDialog.createFlatButton(),
          ActionsFlatButtonToAlertDialog(
            messageButton: 'Sim',
            isEnabled: true,
          ),
          //   InformationAlertDialog.createFlatButton(),
        ],
      ),
    );
    return oQueFazer == 'Sim';
  }
}