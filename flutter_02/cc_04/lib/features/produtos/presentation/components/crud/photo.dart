import 'package:flutter/material.dart';

class PhotoProdutoWidget extends StatelessWidget {
  const PhotoProdutoWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: SizedBox(
        width: 300,
        height: MediaQuery.of(context).size.height * .37,
        child: Stack(
          alignment: Alignment.center,
          children: [
            Container(
              decoration: BoxDecoration(
                shape: BoxShape.circle,
                color: Colors.white,
                border: Border.all(color: Colors.black, width: 5),
                image: const DecorationImage(
                  image: AssetImage('assets/images/sem_foto.png'),
                  fit: BoxFit.cover,
                ),
              ),
            ),
            const Align(
              alignment: Alignment.bottomRight,
              child: Icon(
                Icons.photo_camera,
                size: 48,
              ),
            ),
          ],
        ),
      ),
    );
  }
}
