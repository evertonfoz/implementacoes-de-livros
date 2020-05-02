import 'package:flutter/material.dart';

class LetraTecladoJogoWidget extends StatefulWidget {
  final String letra;
  final bool foiUtilizada;

  const LetraTecladoJogoWidget({this.letra, this.foiUtilizada = false});

  @override
  _LetraTecladoJogoWidgetState createState() => _LetraTecladoJogoWidgetState();

  LetraTecladoJogoWidget copyWith({String letra, bool foiUtilizada}) {
    return LetraTecladoJogoWidget(
      letra: letra ?? this.letra,
      foiUtilizada: foiUtilizada ?? this.foiUtilizada,
    );
  }
}

class _LetraTecladoJogoWidgetState extends State<LetraTecladoJogoWidget> {
  @override
  Widget build(BuildContext context) {
    return Text(
      widget.letra,
      style: TextStyle(
        color: widget.foiUtilizada ? Colors.red : Colors.black,
        fontSize: 40,
      ),
    );
  }
}
