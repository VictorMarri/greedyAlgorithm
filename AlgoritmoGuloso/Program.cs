using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoritmoGuloso
{
    public class Item
    {
        public int Peso { get; set; }
        public int Valor { get; set; }

        public Item(int peso, int valor)
        {
            Peso = peso;
            Valor = valor;
        }

    }

    public class Program
    {
        static void Main(string[] args)
        {
            List<Item> itens = new List<Item>();
            itens.Add(new Item(12,4));
            itens.Add(new Item(2,2));
            itens.Add(new Item(1,1));
            itens.Add(new Item(4,10));
            itens.Add(new Item(1,2));

            int mochilaCapacidade = 15;

            AlgoritmoGuloso(itens, mochilaCapacidade);

            Console.ReadKey();
        }

        static void AlgoritmoGuloso(List<Item> itens, int mochila)
        {
            //Ordenar as entradas
            var itensOrdenados = from i in itens
                                 orderby i.Valor descending
                                 select i;

            //var itensOrdenados = from i in itens
            //                     orderby (i.Valor/i.Peso) descending
            //                     select i;

            int pesoTotal = 0;
            int valorTotal = 0;

            foreach (Item I in itensOrdenados)
            {
                if (I.Peso <= mochila)
                {
                    pesoTotal += I.Peso;
                    valorTotal += I.Valor;
                    mochila -= I.Peso;

                    Console.WriteLine("Peso: {0} - Valor: {1}", I.Peso, I.Valor);
                }
                
            }

           Console.WriteLine("Peso total: {0} - Valor total {1}", pesoTotal, valorTotal);
        }
    }
}
