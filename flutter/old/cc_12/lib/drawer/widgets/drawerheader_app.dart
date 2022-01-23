import 'package:flutter/material.dart';

class DrawerHeaderApp extends StatelessWidget {
  const DrawerHeaderApp({
    Key key,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return DrawerHeader(
      padding: EdgeInsets.zero,
      margin: EdgeInsets.zero,
      decoration: BoxDecoration(
        image: DecorationImage(
          fit: BoxFit.fill,
          image: AssetImage('assets/images/drawer/drawer_header.png'),
        ),
      ),
      child: UserAccountsDrawerHeader(
        decoration: BoxDecoration(color: Colors.transparent),
        accountName: Text(
          "Everton Coimbra de Araújo",
          style: TextStyle(
            color: Colors.black,
          ),
        ),
        accountEmail: Text(
          "evertoncoimbra@gmail.com",
          style: TextStyle(
            color: Colors.black,
          ),
        ),
        currentAccountPicture: CircleAvatar(
          backgroundImage:
              AssetImage('assets/images/drawer/avatar_picture.jpg'),
        ),
        otherAccountsPictures: <Widget>[
//                  CircleAvatar(
//                    backgroundImage: AssetImage(
//                        'assets/images/drawer/avatar_picture_02.jpg'),
//                  ),
          CircleAvatar(
            backgroundImage:
                AssetImage('assets/images/drawer/avatar_picture_03.png'),
          ),
        ],
      ),
    );
  }
}
