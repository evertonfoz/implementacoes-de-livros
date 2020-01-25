using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Capitulo06.ExtensionMethods
{
    public static class ObservableExtensionMethods
    {
        public static void SincronizarColecoes<T>(this ObservableCollection<T> destino, List<T> origem)
        {
            for (int i = 0; i < origem.Count; i++)
            {
                if (destino.Count <= i)
                    destino.Add(origem[i]);
                else if (!destino[i].Equals(origem[i]))
                    destino[i] = origem[i];
                else
                {
                    var notificarListView = destino[i].GetType().GetProperty("NotificarListView").GetValue(destino[i], null);
                    if (notificarListView != null && (bool)notificarListView)
                        destino[i] = origem[i];
                }
            }
            for (int i = origem.Count; i < destino.Count; i++)
            {
                destino.RemoveAt(i);
            }
        }
    }
}
