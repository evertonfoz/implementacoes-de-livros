using Capitulo04.Models;
using System.Collections.Generic;

namespace Capitulo04.Servicos
{
    public class DadosParaTeste
    {
        public List<Veiculo> Veiculos;
        public List<Cliente> Clientes;

        public DadosParaTeste()
        {
            Veiculos = new List<Veiculo>() {
                new Veiculo() {Placa = "ABC-1234", Marca="Fiat", Modelo="147"},
                new Veiculo() {Placa = "DEF-5678", Marca="Chevrolet", Modelo="Monza"},
                new Veiculo() {Placa = "GHI-9012", Marca="Volkswagen", Modelo="Brasília"},
                new Veiculo() {Placa = "JKL-3456", Marca="Ford", Modelo="Corcel"},
                new Veiculo() {Placa = "MNO-7890", Marca="Citroen", Modelo="C4"},
                new Veiculo() {Placa = "PQR-1234", Marca="Honda", Modelo="Civic"}
            };

            Clientes = new List<Cliente>()
            {
                new Cliente() { Nome="Gestrubindo", Endereco="Rua Sai debaixo", Telefone="12345-6789" },
                new Cliente() { Nome="Berssindrílio", Endereco="Rua Sobe, mas não desce", Telefone="01234-5678" },
                new Cliente() { Nome="Kestchbuncio", Endereco="Rua do beco sem fim", Telefone="90123-4567" }
            };

            Clientes[0].Veiculos.Add(Veiculos[0]);
            Clientes[0].Veiculos.Add(Veiculos[1]);
            Clientes[0].Veiculos.Add(Veiculos[2]);

            Clientes[1].Veiculos.Add(Veiculos[3]);
            Clientes[1].Veiculos.Add(Veiculos[4]);

            Clientes[2].Veiculos.Add(Veiculos[5]);
        }
    }
}
