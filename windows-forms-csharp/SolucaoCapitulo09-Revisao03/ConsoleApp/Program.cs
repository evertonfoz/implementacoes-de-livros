using System;
using System.Collections;

namespace ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			IList al = new ArrayList();
			al.Add(1000);
			al.Add("Olá UTFPR");
			al.Add(3000);

			Console.WriteLine(al.Contains(1000)); // True
													 
			//IList al = new ArrayList();
													 //al.Add(1000);
													 //al.Add(2000);
													 //al.Add(3000);

			//al.RemoveAt(1); //Remove o segundo elemento da lista

			//foreach (var item in al)
			//	Console.WriteLine(item);
			//IList al = new ArrayList();
			//al.Add(1000);
			//al.Add(2000);
			//al.Add(3000);

			//al.Remove(1000); //Remove o elemento com vamor 1000 da lista

			//foreach (var item in al)
			//	Console.WriteLine(item);

			//IList al = new ArrayList()
			//			{
			//				8,
			//				"Nove",
			//				10,
			//				11.5F
			//			};

			////Com o foreach
			//foreach (var val in al)
			//	Console.WriteLine(val);

			////Ou com o for
			//for (int i = 0; i < al.Count; i++)
			//	Console.WriteLine(al[i]);

			//ArrayList al = new ArrayList();
			//al.Add(7);
			//al.Add("Oito");
			//al.Add(9);
			//al.Add(10.1f);

			////Acessando um item individual utilizando seu índice
			//int firstElement = (int)al[0]; //retorna 7
			//string secondElement = (string)al[1]; //retorna "Oito"
			//int thirdElement = (int)al[2]; //retorna 9
			//float fourthElement = (float)al[3]; //returna 10.1

			////utilizando a palavra chave var
			//var firstElement = al[0]; //returns 1

			//ArrayList al1 = new ArrayList();
			//al1.Add(5);
			//al1.Add("Seis");
			//al1.Add(7);
			//al1.Add(8.6);

			//IList al2 = new ArrayList(){
			//	1000, 2000
			//};

			//al1.AddRange(al2);

			//for (int i = 0; i < al1.Count; i++)
			//	Console.WriteLine(al1[i]);
		}
	}
}

