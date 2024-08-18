using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fruta_Console.Classes
{
    internal class Menu
    {
        static List<Frutas> FrutasLocal = new List<Frutas>();
        static Frutas frutas;

        static public void TelaPrincipal()
        {
            Console.WriteLine("Bem Vindo(a) a Frutaria do Sr.David");
            Console.WriteLine();

            Console.WriteLine("     \x0022Tabela das Frutas\x0022\n");
            Console.WriteLine(" |    MAÇÃ: R$ 3,00        |\n");
            Console.WriteLine(" |    BANANA: R$ 1,50      |\n");
            Console.WriteLine(" |    LARANJA: R$ 2,00     |\n");
            Console.WriteLine(" |    UVA: R$ 4,00         |\n");
            Console.WriteLine(" |#########################|\n");

            Console.WriteLine("1) COMPRAR");
            Console.WriteLine("2) CARRINHO");
            Console.WriteLine("3) TOTAL\n");

            Console.Write("Digite um numero para navegar no menu: ");
            int numero = int.Parse(Console.ReadLine());
            switch (numero)
            {
                case 1:
                    Console.Clear();
                    Task.Delay(500).Wait();
                    TelaComprar();
                    break;

                case 2:
                    Console.Clear();
                    Task.Delay(500).Wait();
                    TelaCarrinho();
                    break;

                case 3:
                    Console.Clear();
                    Task.Delay(500).Wait();
                    TelaTotal();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Numero errado");
                    Task.Delay(500).Wait();
                    Console.Clear();
                    Task.Delay(500).Wait();
                    TelaPrincipal();
                    break;
            }
        }

        static void TelaComprar()
        {
            Console.WriteLine("     \x0022Tabela das Frutas\x0022\n");
            Console.WriteLine(" |    MAÇÃ: R$ 3,00        |\n");
            Console.WriteLine(" |    BANANA: R$ 1,50      |\n");
            Console.WriteLine(" |    LARANJA: R$ 2,00     |\n");
            Console.WriteLine(" |    UVA: R$ 4,00         |\n");
            Console.WriteLine(" |#########################|\n");
            Console.Write("Quantas Frutas quer Comprar? ");
            int Xqnt = int.Parse(Console.ReadLine());
            for (int i = 0; i < Xqnt; i++)
            {
                Console.WriteLine();
                Console.Write($"{i + 1}) Digite aqui o nome da Fruta que\n" +
                    "que você queira comprar :");
                string Nfruta = Console.ReadLine().ToUpper();
                Console.Write($"Quant: ");
                int Qfruta = int.Parse(Console.ReadLine());
                FrutasLocal.Add(frutas = new Frutas(Nfruta, Qfruta));
            }
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal.");
            Console.ReadKey();
            Console.Clear();
            TelaPrincipal();
        }

        static void TelaCarrinho()
        {
            Console.WriteLine("Seu Carrinho:\n");
            foreach (var fruta in FrutasLocal)
            {
                Console.WriteLine($"{fruta.Nome} - Quantidade: {fruta.Quantidade}");
            }
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal.");
            Console.ReadKey();
            Console.Clear();
            TelaPrincipal();
        }
        static void TelaTotal()
        {
            Venda.SomaComprar(FrutasLocal);
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal.");
            Console.ReadKey();
            Console.Clear();
            TelaPrincipal();
        }
    }

    class Frutas
    {
        public string Nome { get; private set; }
        public int Quantidade { get; private set; }

        public Frutas(string nome, int quantidade)
        {
            Nome = nome;
            Quantidade = quantidade;
        }
    }

    class Venda
    {
       static decimal Desconto10 = 0.10M;
       static decimal Desconto5 = 5.0M;

       static public void SomaComprar(List<Frutas> frutas)
        {
            decimal total = 0.0M;
            int totalFrutas = 0;

            foreach (Frutas fruta in frutas)
            {
                switch (fruta.Nome)
                {
                    case "MAÇÃ":
                        total += fruta.Quantidade * 3.00M;
                        break;
                    case "BANANA":
                        total += fruta.Quantidade * 1.50M;
                        break;
                    case "LARANJA":
                        total += fruta.Quantidade * 2.00M;
                        break;
                    case "UVA":
                        total += fruta.Quantidade * 4.00M;
                        break;
                }
                totalFrutas += fruta.Quantidade;
            }

            if (total > 50.00M)
            {
                total -= total * Desconto10;
            }

            if (totalFrutas > 20)
            {
                total -= Desconto5;
            }

            Console.WriteLine($"Total após descontos: R$ {total:F2}");
        }
    }
}
