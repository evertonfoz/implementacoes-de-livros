# Implementações — Orientação a Objetos em C#

Este diretório contém os projetos C# implementados a partir do livro  
**"Orientação a Objetos em C#: Conceitos e implementações em .NET"**  
de **Everton Coimbra de Araújo** — Casa do Código.

## Requisitos

- **.NET SDK 10.0.103** (ou superior compatível)
- Visual Studio Code com extensão C# Dev Kit

## Estrutura

| Pasta         | Capítulo | Conteúdo |
|--------------|----------|----------|
| `capitulo01/` | Cap. 1 — Introdução à OO | Conceitual — sem código |
| `capitulo02/` | Cap. 2 — Iniciando a implementação | `PrimeiroProjeto`, `Banco`, `Circulo` |
| `capitulo03/` | Cap. 3 — Associações e inicialização | *(a implementar)* |
| `capitulo04/` | Cap. 4 — Coleções e Identidade | *(a implementar)* |
| `capitulo05/` | Cap. 5 — Herança e Polimorfismo | *(a implementar)* |
| `capitulo06/` | Cap. 6 — Padrões de Projetos | *(a implementar)* |
| `capitulo07/` | Cap. 7 — Solução em Camadas | *(a implementar)* |
| `capitulo08/` | Cap. 8 — Acesso a banco de dados | *(a implementar)* |
| `capitulo09/` | Cap. 9 — Uso do EF Core | *(a implementar)* |

## Como executar um projeto

```bash
# Entrar na pasta do projeto desejado
cd capitulo02/PrimeiroProjeto

# Executar
dotnet run

# Executar passando argumentos (ex: Cap. 2 - demonstração de args)
dotnet run -- Casa do Código
```

## Sobre os warnings CS8618 / CS8601

Esses avisos são gerados pelo recurso **Nullable Reference Types** do C#, que alerta sobre possíveis valores nulos em propriedades não inicializadas. O livro explica esse comportamento e aborda o tratamento adequado nos capítulos seguintes. Os avisos **não impedem a execução** dos programas nesta fase inicial.
