using System;
using System.Threading.Tasks;

namespace Fruta_Console.Classes
{
    internal class Menu
    {
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

            Console.WriteLine("1)" + "COMPRAR");
            Console.WriteLine("2)" + "CARRINHO");
            Console.WriteLine("3)" + "TOTAL\n");

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
                    break;

                case 3:
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
                Console.Write($"{i+1}) Digite aqui o nome da Fruta que\n" +
                    "que você queira comprar :");
                string Nfruta = Console.ReadLine().ToUpper();
                Console.Write($"Quant: ");
                string Qfruta = Console.ReadLine().ToUpper();
            }
        }
    }
}
