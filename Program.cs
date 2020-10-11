using System;
using System.Threading;

namespace Stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Start(int time, ETypeTime typeTime)
        {

            int currentTime = 0;
            int multiplier = (int)typeTime;

            while (currentTime != (time * multiplier))
            {
                Console.Clear();
                currentTime++;
                Console.WriteLine(currentTime);
                Thread.Sleep(1000);
            }
            Finish();
        }

        static void Finish()
        {
            int cont = 3;
            while (cont > 0)
            {
                Console.Clear();
                Console.Write($"Stopwatch finalizado! Reiniciando em {cont}...");
                cont--;
                Thread.Sleep(1000);
            }
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Bem-vindo ao teste Stopwatch!\n");

            Console.WriteLine("Trabalharemos com minutos ou segundos?");
            Console.WriteLine("Para segundos digite o valor seguido de 's'. Ex.: 1s");
            Console.WriteLine("Para segundos digite o valor seguido de 'm'. Ex.: 1m");
            Console.WriteLine("Para sair: 0");

            string data = Console.ReadLine().ToLower();
            char type = char.Parse(data.Substring(data.Length - 1, 1));
            int time = int.Parse(data.Substring(0, data.Length - 1));

            switch (type)
            {
                case 's': Start(time, ETypeTime.Segundo); break;
                case 'm': Start(time, ETypeTime.Minuto); break;
                case '0': System.Environment.Exit(0); break;
                default:
                    {
                        Console.WriteLine("Tipo inválido, por favor tente novamente.");
                        Thread.Sleep(2000);
                        Finish();
                        Menu();
                        break;
                    }
            }
        }
    }

    enum ETypeTime
    {
        Segundo = 1,
        Minuto = 60
    }
}
