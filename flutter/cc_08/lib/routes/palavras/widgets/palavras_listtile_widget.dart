import 'package:flutter/material.dart';

class PalavrasListTileWidget extends StatelessWidget {
  final String title;
  final Widget trailing;

  const PalavrasListTileWidget({
    Key? key,
    required this.title,
    required this.trailing,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return ListTile(
      contentPadding: const EdgeInsets.only(left: 5, bottom: 5, top: 3),
      title: Text(
        title,
      ),
      trailing: trailing,
    );
  }
}
