import 'dart:io';

import 'package:shelf/shelf.dart';
import 'package:shelf/shelf_io.dart';
import 'package:shelf_router/shelf_router.dart';

// Configuração de rotas
final _router = Router()
  ..get('/', _rootHandler)
  ..get('/echo/<message>', _echoHandler);

Response _rootHandler(Request req) {
  return Response.ok('Hello, World!\n');
}

Response _echoHandler(Request request) {
  final message = request.params['message'];
  return Response.ok('$message\n');
}

void main(List<String> args) async {
  // Use qualquer host disponível ou IP de contêiner (geralmente `0.0.0.0`).
  final ip = InternetAddress.anyIPv4;

  // Configure um pipeline que registre solicitações.
  final handler = Pipeline().addMiddleware(logRequests()).addHandler(_router);

  // Para execução em containers, respeitamos a variável de ambiente PORT.
  final port = int.parse(Platform.environment['PORT'] ?? '8080');
  final server = await serve(handler, ip, port);
  print('Servidor ouvindo na porta ${server.port}');
}
