import 'package:flutter/cupertino.dart';

class InformationCupertinoAlertDialogWidget extends StatelessWidget {
  final String title;
  final String message;
  final List<Widget> actions;

  const InformationCupertinoAlertDialogWidget({
    Key? key,
    required this.title,
    required this.message,
    required this.actions,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return CupertinoAlertDialog(
      title: Column(
        children: <Widget>[
          Text(title),
          const SizedBox(
            height: 20,
          ),
        ],
      ),
      content: Text(message),
      actions: actions,
    );
  }
}
