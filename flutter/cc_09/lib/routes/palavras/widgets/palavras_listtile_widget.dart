import 'package:flutter/material.dart';

class PalavrasListTileWidget extends StatelessWidget {
  final String title;
  final Widget trailing;
  final double listTileHeight;
  final Color? color;

  const PalavrasListTileWidget({
    Key? key,
    required this.title,
    required this.trailing,
    required this.listTileHeight,
    required this.color,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      height: listTileHeight,
      color: color,
      child: ListTile(
        contentPadding: const EdgeInsets.only(left: 5, bottom: 5, top: 3),
        title: Text(
          title,
        ),
        trailing: trailing,
      ),
    );
  }
}
