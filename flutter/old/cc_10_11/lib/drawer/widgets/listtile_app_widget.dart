import 'package:flutter/material.dart';

class ListTileAppWidget extends StatelessWidget {
  final EdgeInsets contentPadding;
  final ImageProvider avatarImage;
  final String titleText;
  final String subtitleText;
  final Function onTap;

  const ListTileAppWidget({
    this.contentPadding =
        const EdgeInsets.only(left: 54.0, top: 0.0, bottom: 8.0),
    this.avatarImage,
    @required this.titleText,
    @required this.subtitleText,
    @required this.onTap,
  });

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: contentPadding,
      child: GestureDetector(
        onTap: this.onTap,
        child: Row(
          children: <Widget>[
            (avatarImage == null)
                ? Container(
                    width: 0,
                  )
                : Container(
                    width: 30.0,
                    height: 30.0,
                    decoration: BoxDecoration(
                      shape: BoxShape.circle,
                      image: DecorationImage(
                        image: avatarImage,
                        fit: BoxFit.cover,
                      ),
                    ),
                  ),
            Expanded(
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: <Widget>[
                  Text(titleText),
                  Text(
                    subtitleText,
                    style: TextStyle(
                      fontSize: 10.0,
                    ),
                  ),
                ],
              ),
            ),
            Icon(
              Icons.arrow_forward,
              color: Colors.black38,
            )
          ],
        ),
      ),
    );
  }
}
