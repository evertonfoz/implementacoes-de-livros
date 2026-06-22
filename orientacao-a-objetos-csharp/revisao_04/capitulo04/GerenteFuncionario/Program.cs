using ComplementarDois_GerenteFuncionario.Model;

// =============================================
// Demonstração: Associação Bidirecional
// Gerente ↔ Funcionario
// =============================================

var gerente1 = new Gerente { Nome = "Ana" };
var gerente2 = new Gerente { Nome = "Bruno" };

var func1 = new Funcionario { Nome = "Carlos" };
var func2 = new Funcionario { Nome = "Diana" };
var func3 = new Funcionario { Nome = "Eduardo" };

// Atribuindo gerente via Funcionario.Gerente (set customizado)
func1.Gerente = gerente1;
func2.Gerente = gerente1;
func3.Gerente = gerente2;

Console.WriteLine("=== Associações iniciais ===");
Console.WriteLine($"Funcionários de {gerente1.Nome}: {gerente1.Funcionarios.Count}");
foreach (var f in gerente1.Funcionarios)
    Console.WriteLine($"  ==> {f.Nome}");

Console.WriteLine($"Funcionários de {gerente2.Nome}: {gerente2.Funcionarios.Count}");
foreach (var f in gerente2.Funcionarios)
    Console.WriteLine($"  ==> {f.Nome}");

// =============================================
// Mudança de gerente: consistência automática
// =============================================
Console.WriteLine("\n=== Transferindo Carlos para gerente Bruno ===");
func1.Gerente = gerente2;

Console.WriteLine($"Funcionários de {gerente1.Nome}: {gerente1.Funcionarios.Count}");
foreach (var f in gerente1.Funcionarios)
    Console.WriteLine($"  ==> {f.Nome}");

Console.WriteLine($"Funcionários de {gerente2.Nome}: {gerente2.Funcionarios.Count}");
foreach (var f in gerente2.Funcionarios)
    Console.WriteLine($"  ==> {f.Nome}");

// =============================================
// Registrar via método público do Gerente
// =============================================
Console.WriteLine("\n=== Registrando Eduardo também com Ana via Gerente.RegistrarFuncionario ===");
gerente1.RegistrarFuncionario(func3);

Console.WriteLine($"Funcionários de {gerente1.Nome}: {gerente1.Funcionarios.Count}");
foreach (var f in gerente1.Funcionarios)
    Console.WriteLine($"  ==> {f.Nome}");

Console.WriteLine($"Funcionários de {gerente2.Nome}: {gerente2.Funcionarios.Count}");
foreach (var f in gerente2.Funcionarios)
    Console.WriteLine($"  ==> {f.Nome}");

Console.Write("\nPressione qualquer tecla para encerrar.");
Console.ReadKey();
