import 'package:flutter/material.dart';

class PalavrasListTileWidget extends StatelessWidget {
  final String title;
  final Widget trailing;
  final double listTileHeight;
  final Color color;
  const PalavrasListTileWidget(
      {this.title, this.trailing, this.listTileHeight, this.color,});

  @override
  Widget build(BuildContext context) {
    return Container(
      color: this.color,
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
