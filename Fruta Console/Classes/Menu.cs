using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Fruta_Console.Classes
{
    internal class Menu
    {
        static List<Frutas> FrutasLocal = new List<Frutas>();
        static Frutas frutas;

        // Função tela principal responsavel por gerar o menu para navegação
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
        // Função tela para mostrar o menu de Comprar
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
            Venda.SomaComprar(FrutasLocal); // Recalcula o total após adicionar frutas
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal.");
            Console.ReadKey();
            Console.Clear();
            TelaPrincipal();
        }
        // Função tela para mostrar uma listas das frutas adicionado no carrinho
        static void TelaCarrinho()
        {
            Console.WriteLine("Seu Carrinho:\n");
            foreach (Frutas fruta in FrutasLocal)
            {
                Console.WriteLine($"{fruta.Nome} - Quantidade: {fruta.Quantidade}");
            }
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal.");
            Console.ReadKey();
            Console.Clear();
            TelaPrincipal();
        }
        // Função tela para mostrar o recibo do produto
        static void TelaTotal()
        {
            Venda.Recibo();
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal.");
            Console.ReadKey();
            Console.Clear();
            TelaPrincipal();
        }
    }
    // Classe Frutas resposnavel por armazenar os nomes
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
    // Classe Venda resposnavel por calcular as compras e o recibo
    class Venda
    {
        static decimal Desconto10 = 0.10M;
        static decimal Desconto5 = 5.0M;

        static decimal Total = 0.0M;
        static int TotalFrutas = 0;
        static public void SomaComprar(List<Frutas> frutas)
        {

            foreach (Frutas fruta in frutas)
            {
                switch (fruta.Nome)
                {
                    case "MAÇÃ":
                        Total += fruta.Quantidade * 3.00M;
                        break;
                    case "BANANA":
                        Total += fruta.Quantidade * 1.50M;
                        break;
                    case "LARANJA":
                        Total += fruta.Quantidade * 2.00M;
                        break;
                    case "UVA":
                        Total += fruta.Quantidade * 4.00M;
                        break;
                }
                TotalFrutas += fruta.Quantidade;

            }
                if (Total > 50.00M)
                {
                    Total -= Total * Desconto10;
                }

                if (TotalFrutas > 20)
                {
                    Total -= Desconto5;
                }
            
        }

        static public void Recibo()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("          RECIBO DE COMPRA         ");
            Console.WriteLine("===================================");
            Console.WriteLine($"Total: R$ {Total + (Total * Desconto10) + Desconto5:F2}");
            if (Total > 50.00M)
            {
                Console.WriteLine($"Desconto (10%): -R$ {Total * Desconto10:F2}");
            }
            if (TotalFrutas > 20)
            {
                Console.WriteLine($"Desconto adicional: -R$ {Desconto5:F2}");
            }
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Total com Desconto: R$ {Total:F2}");
            Console.WriteLine("===================================");

        }
    }
}
