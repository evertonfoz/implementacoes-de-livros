import 'package:flash/flash.dart';
import 'package:flutter/material.dart';

void showBottomSnackBar({
  bool persistent = true,
  EdgeInsets margin = EdgeInsets.zero,
  required BuildContext context,
  int durationSeconds = 2,
  String? title,
  String? content,
}) {
  assert(title != null || content != null,
      'É preciso informar o título ou conteúdo');

  showFlash(
    context: context,
    // persistent: persistent,
    duration: Duration(seconds: durationSeconds),
    builder: (_, controller) {
      return Flash(
        barrierDismissible: false,
        controller: controller,
        margin: margin,
        behavior: FlashBehavior.fixed,
        position: FlashPosition.bottom,
        borderRadius: const BorderRadius.only(
          topLeft: Radius.circular(8),
          topRight: Radius.circular(8),
        ),
        borderColor: Colors.black,
        backgroundColor: Colors.black,
        forwardAnimationCurve: Curves.easeInCirc,
        reverseAnimationCurve: Curves.bounceIn,
        child: FlashBar(
          padding: const EdgeInsets.all(25),
          title: _buildTitle(title),
          content: _buildContent(content),
          indicatorColor: Colors.red,
          icon: const Icon(
            Icons.info_outline,
            color: Colors.white,
            size: 40,
          ),
        ),
      );
    },
  );
}

_buildTitle(String? title) {
  if (title == null) {
    return Container();
  }

  return Text(
    title,
    style: const TextStyle(
      fontSize: 30,
      fontWeight: FontWeight.bold,
    ),
  );
}

_buildContent(String? content) {
  if (content == null) {
    return Container();
  }
  return Text(
    content,
    style: const TextStyle(fontSize: 20),
  );
}
