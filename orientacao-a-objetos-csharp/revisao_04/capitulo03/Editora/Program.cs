using ComplementarUm_Editora;

// =================================================
// Demonstração: Editora, Livro e Autor
// Navegabilidade bidirecional: Livro conhece a Editora
// e a Editora registra automaticamente seus Livros
// =================================================

var casaDoCodigo = new Editora
{
    RazaoSocial = "Casa do Código",
    EMail = "contato@casadocodigo.com.br"
};

var autor1 = new Autor
{
    Nome = "Everton Coimbra de Araújo",
    EMail = "everton@email.com"
};

var livro1 = new Livro
{
    Titulo = "Orientação a Objetos em C#",
    ISBN = "978-65-86110-00-5"
};
livro1.RegistrarAutor(autor1);

// Ao atribuir a editora, o livro se registra automaticamente nela
livro1.Editora = casaDoCodigo;

var livro2 = new Livro
{
    Titulo = "C# e Visual Studio",
    ISBN = "978-00-00000-00-0"
};
livro2.Editora = casaDoCodigo;

// Verificando a navegabilidade bidirecional
Console.WriteLine($"Editora: {casaDoCodigo.RazaoSocial}");
Console.WriteLine($"Total de livros registrados: {casaDoCodigo.ObterQuantidadeLivros()}");
Console.WriteLine("Livros:");
for (int i = 0; i < casaDoCodigo.ObterQuantidadeLivros(); i++)
{
    var livro = casaDoCodigo.Livros[i];
    Console.WriteLine($"  ==> {livro.Titulo} (ISBN: {livro.ISBN})");
    Console.WriteLine($"      Autores: {livro.ObterQuantidadeAutores()}");
    for (int j = 0; j < livro.ObterQuantidadeAutores(); j++)
    {
        Console.WriteLine($"        - {livro.Autores[j].Nome}");
    }
}

Console.Write("\nPressione qualquer tecla para encerrar.");
Console.ReadKey();
