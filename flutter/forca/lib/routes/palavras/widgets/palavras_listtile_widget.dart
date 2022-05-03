import 'package:flutter/material.dart';

class PalavrasListTileWidget extends StatelessWidget {
  final String title;
  final Widget trailing;

  const PalavrasListTileWidget({required this.title, required this.trailing});

  @override
  Widget build(BuildContext context) {
    return Container(
      child: ListTile(
        contentPadding: EdgeInsets.only(left: 5, bottom: 5, top: 3),
        title: Text(
          title,
        ),
        trailing: trailing,
      ),
    );
  }
}