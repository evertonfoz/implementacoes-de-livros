using System.Collections;

namespace ComplementarUm_CollectionVariosTipos
{
    class Program
    {
        static void Main(string[] args)
        {
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
