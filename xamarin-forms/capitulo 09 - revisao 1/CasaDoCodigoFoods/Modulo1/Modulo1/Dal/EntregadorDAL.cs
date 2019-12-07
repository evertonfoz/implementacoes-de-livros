using Modulo1.Modelo;
using System.Collections.ObjectModel;

namespace Modulo1.Dal
{
    public class EntregadorDAL
    {
        private ObservableCollection<Entregador> Entregadores = new ObservableCollection<Entregador>();
        private static EntregadorDAL EntregadorInstance = new EntregadorDAL();

        private EntregadorDAL()
        {
            Entregadores.Add(new Entregador()
            {
                Id = 1,
                Nome = "Brauzio",
                Telefone = "Asdrugio"
            });
            Entregadores.Add(new Entregador()
            {
                Id = 2,
                Nome = "Entencius",
                Telefone = "Gesfredio"
            });
            Entregadores.Add(new Entregador()
            {
                Id = 3,
                Nome = "Cartucious",
                Telefone = "Gesfrundio"
            });
            Entregadores.Add(new Entregador()
            {
                Id = 4,
                Nome = "Adoliterio",
                Telefone = "Kentencio"
            });
            Entregadores.Add(new Entregador()
            {
                Id = 5,
                Nome = "Castrogildo",
                Telefone = "Gesifrelio"
            });
            Entregadores.Add(new Entregador()
            {
                Id = 6,
                Nome = "Asdrugio",
                Telefone = "Brauzio"
            });
            Entregadores.Add(new Entregador()
            {
                Id = 7,
                Nome = "Gesfredio",
                Telefone = "Entencius"
            });
            Entregadores.Add(new Entregador()
            {
                Id = 8,
                Nome = "Gesfrundio",
                Telefone = "Cartucious"
            });
            Entregadores.Add(new Entregador()
            {
                Id = 9,
                Nome = "Kentencio",
                Telefone = "Adoliterio"
            });
            Entregadores.Add(new Entregador()
            {
                Id = 10,
                Nome = "Gesifrelio",
                Telefone = "Castrogildo"
            });
        }

        public static EntregadorDAL GetInstance()
        {
            return EntregadorInstance;

        }
        public ObservableCollection<Entregador> GetAll()
        {
            return Entregadores;
        }

        public void Add(Entregador entregador)
        {
            this.Entregadores.Add(entregador);
        }
    }
}
