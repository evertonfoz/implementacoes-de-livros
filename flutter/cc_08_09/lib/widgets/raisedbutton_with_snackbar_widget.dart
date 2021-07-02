import 'package:flutter/material.dart';

class RaisedButtonWithSnackbarWidget extends StatelessWidget {
  bool onPressedVisible;
  String buttonText;
  String textToSnackBar;
  Function onButtonPressed;
  Function onStackBarClosed;

  RaisedButtonWithSnackbarWidget({
    @required this.onPressedVisible,
    @required this.buttonText,
    @required this.textToSnackBar,
    @required this.onButtonPressed,
    @required this.onStackBarClosed,
  });

  @override
  Widget build(BuildContext context) {
    return RaisedButton(
      child: Text(this.buttonText),
      onPressed: this.onPressedVisible
          ? () {
              FocusScope.of(context).unfocus();
              this.onButtonPressed();

              Scaffold.of(context)
                  .showSnackBar(
                    SnackBar(
                      backgroundColor: Colors.indigo,
                      content: Text(
                        this.textToSnackBar,
                        textAlign: TextAlign.center,
                        style: TextStyle(
                          fontWeight: FontWeight.bold,
                        ),
                      ),
                      duration: Duration(seconds: 3),
                    ),
                  )
                  .closed
                  .then((_) => this.onStackBarClosed());
            }
          : null,
    );
  }
}
