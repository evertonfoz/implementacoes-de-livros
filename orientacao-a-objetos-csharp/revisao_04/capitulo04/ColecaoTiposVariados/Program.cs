using System.Collections;

namespace ComplementarUm_CollectionVariosTipos
{
    class Program
    {
        static void Main(string[] args)
        {
            // ArrayList aceita qualquer tipo derivado de object
            // (abordagem pré-Generics, usada aqui para fins didáticos)
            var allDataType = new ArrayList();
            allDataType.Add(1);
            allDataType.Add("Dois");
            allDataType.Add(3.4);
            allDataType.Add('5');
            allDataType.Add(true);

            foreach (var item in allDataType)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
