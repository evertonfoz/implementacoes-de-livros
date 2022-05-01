import 'package:equatable/equatable.dart';
import 'package:json_annotation/json_annotation.dart';

part 'palavra_model.g.dart';

@JsonSerializable()
// ignore: must_be_immutable
class PalavraModel extends Equatable {
  String? palavraID;
  final String palavra;
  final String ajuda;

  PalavraModel({
    this.palavraID,
    required this.palavra,
    required this.ajuda,
  });

  bool get isValid => palavra.isNotEmpty && ajuda.isNotEmpty;

  static PalavraModel empty() {
    return PalavraModel(
      palavraID: '',
      palavra: '',
      ajuda: '',
    );
  }

  PalavraModel copyWith({
    String? palavraID,
    String? palavra,
    String? ajuda,
  }) {
    return PalavraModel(
      palavraID: palavraID ?? this.palavraID,
      palavra: palavra ?? this.palavra,
      ajuda: ajuda ?? this.ajuda,
    );
  }

  @override
  List<Object> get props => [palavraID ?? ''];

  factory PalavraModel.fromJson(Map<String, dynamic> json) =>
      _$PalavraModelFromJson(json);
  Map<String, dynamic> toJson() => _$PalavraModelToJson(this);
}
