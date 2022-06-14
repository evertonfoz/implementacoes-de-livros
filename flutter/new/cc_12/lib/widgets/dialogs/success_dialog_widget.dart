import 'package:flutter/material.dart';

class SuccessDialogWidget extends StatelessWidget {
  final VoidCallback onDismissed;

  const SuccessDialogWidget({
    Key? key,
    required this.onDismissed,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(20),
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: <Widget>[
          Row(
            mainAxisSize: MainAxisSize.max,
            mainAxisAlignment: MainAxisAlignment.center,
            children: const <Widget>[
              Icon(Icons.info),
              Flexible(
                child: Padding(
                  padding: EdgeInsets.all(10),
                  child: Text(
                    'Dados informados com sucesso!',
                    softWrap: true,
                  ),
                ),
              ),
            ],
          ),
          TextButton(
            child: const Text('OK'),
            onPressed: onDismissed,
          ),
        ],
      ),
    );
  }
}
