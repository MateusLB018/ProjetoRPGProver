using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPGProver.Classes
{
    public partial class Classes
    {
        public static void Criando()
        {
        teste:
            int numero = 27;

            Console.WriteLine("Escolha o status de sua classe:  ");
            Console.WriteLine("Você tem : " + numero + " de pontos para gastar");
            Console.WriteLine("inteligencia: ");
            int inteligencia = Convert.ToInt32(Console.ReadLine());
            numero = numero - inteligencia;
            Console.WriteLine(" 1-Clérigo\n 2-Guerreiro\n 3-Mago");

            var result = Console.ReadKey();
            string answ = "";

            switch (result.KeyChar)
            {
                case '1':



                    Console.WriteLine("o stats do Clérigo é:  ");
                    Console.WriteLine(@"
            Inteligencia = 8
            Força = 12
            Fe = 16
            Vitalidade = 11
            Energia = 10
            Magia = 11
            Defesa = 11
            Vigor = 9");

                    Console.WriteLine("Está satisfeito com a sua escolha ?");
                    Console.WriteLine("--------->sim///////////---------->não");
                    answ = Console.ReadLine();
                    if (answ == "sim")
                    {
                        Classe Mago = new Classe("Clérigo, Stats: ", 8, 12, 16, 11, 10, 11, 11, 9);
                    }
                    else
                    {
                        goto teste;
                    }
                    break;
                case '2':
                    Console.WriteLine("o stats do Guerreiro é:  ");
                    Console.WriteLine(@"
            Inteligencia = 8
            Força = 13
            Fe = 9
            Vitalidade = 11
            Energia = 13
            Magia = 5
            Defesa = 12
            Vigor = 14 ");

                    Console.WriteLine("Está satisfeito com a sua escolha ?");
                    Console.WriteLine("--------->sim///////////---------->não");
                    answ = Console.ReadLine();
                    if (answ == "sim")
                    {
                        Classe Mago = new Classe("Guerreiro, Stats: ", 8, 13, 9, 11, 13, 5, 12, 14);

                    }
                    else
                    {
                        goto teste;
                    }
                    break;
                case '3':
                    Console.WriteLine("o stats do Mago é:  ");
                    Console.WriteLine(@"
                Inteligencia = 16;
                Força = 7
                Fe = 7
                Vitalidade = 7
                Energia = 10
                Magia = 16
                Defesa = 7
                Vigor = 9");

                    Console.WriteLine("Está satisfeito com a sua escolha ?");
                    Console.WriteLine("--------->sim///////////---------->não");
                    if (answ == "sim")
                    {
                        Classe Mago = new Classe("Mago, Stats: ", 16, 7, 7, 7, 10, 16, 7, 9);
                    }
                    else
                    {
                        goto teste;
                    }
                    break;
                default:
                    break;
            }
            /*Classe Build = new Classe();
            List<Classe> ClasseNova = new List<Classe>();
            ClasseNova.Add(Build);

            try
            {
                using (TextWriter tw = new StreamWriter("SavedList.txt"))
                    foreach (var item in ClasseNova)
                    {
                        tw.WriteLine($"{item.TipoClasse} - {item.Inteligencia} - {item.Força} - {item.Fe} - {item.Vitalidade} - {item.Energia} - {item.Magia} - {item.Defesa} - {item.Vigor}");
                    }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }*/
        }
    }
}

    }
}
