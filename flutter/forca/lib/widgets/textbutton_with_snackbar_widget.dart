import 'package:flutter/material.dart';

class TextButtonWithSnackbarWidget extends StatelessWidget {
  final bool onPressedVisible;
  final String buttonText;
  final String successTextToSnackBar;
  final Function onButtonPressed;
  final Function onSnackBarClosed;
  final String failTextToSnackBar;

  const TextButtonWithSnackbarWidget({
    Key? key,
    required this.onPressedVisible,
    required this.buttonText,
    required this.successTextToSnackBar,
    required this.onButtonPressed,
    required this.onSnackBarClosed,
    required this.failTextToSnackBar,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return TextButton(
      child: Text(buttonText),
      onPressed: onPressedVisible ? () => _onPressedTextButton(context) : null,
    );
  }

  _onPressedTextButton(BuildContext buildContext) async {
    String textToSnackBar = successTextToSnackBar;
    bool success = true;
    FocusScope.of(buildContext).unfocus();

    try {
      await onButtonPressed();
    } catch (e) {
      textToSnackBar = failTextToSnackBar + ': ' + e.toString();
      success = false;
    }

    ScaffoldMessenger.of(buildContext)
        .showSnackBar(
          SnackBar(
            backgroundColor: (success) ? Colors.indigo : Colors.red,
            content: Text(
              textToSnackBar,
              textAlign: TextAlign.center,
              style: const TextStyle(
                fontWeight: FontWeight.bold,
              ),
            ),
            duration: Duration(seconds: (success) ? 3 : 5),
          ),
        )
        .closed
        .then((_) => (success) ? onSnackBarClosed() : () {});
  }
}
