using SegundoProjeto;

// =============================================
// Demonstração 1: Associação com Departamentos
// =============================================

// Criação usando Object Initializers (Cap. 3 — Inicializadores de Objeto)
var iesUTFPR = new Instituicao
{
    Nome = "UTFPR",
    Endereco = new Endereco
    {
        Rua = "Brasil",
        Numero = "1000"
    }
};

var iesCC = new Instituicao
{
    Nome = "Casa do Código",
    Endereco = new Endereco
    {
        Bairro = "Liberdade"
    }
};

// Criação de departamentos usando construtor (estado mínimo válido)
var dptoEnsino    = new Departamento("Computação");
var dptoAlimentos = new Departamento("Alimentos");
var dptoRevisao   = new Departamento("Revisão Escrita");

// Registrando departamentos em cada instituição
iesUTFPR.RegistrarDepartamento(dptoEnsino);
iesUTFPR.RegistrarDepartamento(dptoAlimentos);

iesCC.RegistrarDepartamento(dptoRevisao);

// Exibindo departamentos usando loop for e acesso por índice
Console.WriteLine("UTFPR");
for (int i = 0; i < iesUTFPR.ObterQuantidadeDepartamentos(); i++)
{
    Console.WriteLine($"==> {iesUTFPR.Departamentos[i].Nome}");
}

Console.WriteLine("Casa do Código");
for (int i = 0; i < iesCC.ObterQuantidadeDepartamentos(); i++)
{
    Console.WriteLine($"==> {iesCC.Departamentos[i].Nome}");
}

// =============================================
// Demonstração 2: Acesso via método DepartamentoPorIndice
// =============================================
Console.WriteLine("\nAcesso via DepartamentoPorIndice:");
for (int i = 0; i < iesUTFPR.ObterQuantidadeDepartamentos(); i++)
{
    Console.WriteLine($"==> {iesUTFPR.DepartamentoPorIndice(i).Nome}");
}

Console.Write("\nPressione qualquer tecla para continuar");
Console.ReadKey();
