import 'package:flutter/material.dart';

class CheckBoxWidget extends StatefulWidget {
  final String text;

  const CheckBoxWidget({
    Key? key,
    required this.text,
  }) : super(key: key);

  @override
  // ignore: library_private_types_in_public_api
  _CheckBoxWidgetState createState() => _CheckBoxWidgetState();
}

class _CheckBoxWidgetState extends State<CheckBoxWidget> {
  bool _checked = false;

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Checkbox(
          value: _checked,
          onChanged: (value) {
            setState(() {
              _checked = !_checked;
            });
          },
        ),
        Text(widget.text),
      ],
    );
  }
}
