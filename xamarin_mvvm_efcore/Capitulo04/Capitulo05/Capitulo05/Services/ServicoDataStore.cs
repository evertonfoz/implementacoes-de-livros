using Capitulo05.Models;
using System.Collections.Generic;
using System.Linq;

namespace Capitulo05.Services
{
    public class ServicoDataStore : IDataStore<Servico>
    {
        private static List<Servico> servicos = new List<Servico>()
            {
                new Servico() { ServicoID = 1, Nome = "Freios", Valor = 100},
                new Servico() { ServicoID = 2, Nome = "Suspensão", Valor = 200},
                new Servico() { ServicoID = 3, Nome = "Caixa de direção", Valor = 300},
                new Servico() { ServicoID = 4, Nome = "Caixa de câmbio", Valor = 400},
                new Servico() { ServicoID = 5, Nome = "Alinhamento/Balanceamento", Valor = 25}
            };

        public void Add(Servico servico)
        {
            servicos.Add(servico);
        }

        public void Delete(Servico servico)
        {
            var _servico = servicos.Where((Servico s) => s.ServicoID == servico.ServicoID).FirstOrDefault();
            servicos.Remove(_servico);
        }

        public IEnumerable<Servico> GetAll()
        {
            return servicos;
        }

        public Servico GetById(long? id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Servico servico)
        {
            //var _servico = servicos.Where((Servico s) => s.ServicoID == servico.ServicoID).FirstOrDefault();
            //servicos.Remove(_servico);
            //servicos.Add(servico);

            if (servico.ServicoID != null)
            {
                var _servico = servicos.Where((Servico s) => s.ServicoID == servico.ServicoID).FirstOrDefault();
                servicos.Remove(_servico);
            }
            else
            {
                servico.ServicoID = servicos.Max(s => s.ServicoID) + 1;
            }
            Add(servico);
        }
    }
}
