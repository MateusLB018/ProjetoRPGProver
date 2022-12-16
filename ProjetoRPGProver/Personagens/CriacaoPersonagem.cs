/*using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using ProjetoRPGProver.Models;
using Spectre.Console;

namespace ProjetoRPGProver.Personagens
{
    public partial class Personagens

    {
        public static void Criando()
        {

            Console.WriteLine("Qual é o seu nome: ");
            string nome = Console.ReadLine();



            Console.WriteLine("Qual é a sua idade: ");
            int idade = Convert.ToInt32(Console.ReadLine());



            Console.WriteLine("Qual é o seu peso: ");
            double peso = Convert.ToDouble(Console.ReadLine());
            //Skill.rolamento = peso;



            Console.WriteLine("Qual é o seu sexo: M/F ");
            string sexo = Console.ReadLine();

        teste:
            Console.Clear();
            Console.WriteLine(" Escolha seu item inicial : ");
            Console.WriteLine(" 1-Anel da Vida\n 2-Bomba Negra\n 3-Osso do Regresso\n 4-Coroa de Escamas\n 5-Medalhão de prata\n");
            var result = Console.ReadKey();
            //string answ = "";
            string itemIni = "";

            switch (result.KeyChar)
            {
                case '1':

                    Console.WriteLine("SIM::::::::::::::::::::::::::");
                    Console.WriteLine("DIGITE [C] PARA CANCELAR");
                    itemIni = Console.ReadLine();
                    if (itemIni != "C" || itemIni != "c")
                    {
                        itemIni = "Anel da Vida";
                    }
                    else
                    {
                        goto teste;
                    }
                    break;
                case '2':
                    Console.WriteLine(" Então você escolhe a Bomba negra, o mais poderoso explosivo... tem certeza ? ");
                    Console.WriteLine("--------->sim///////////---------->não");
                    itemIni = Console.ReadLine();
                    if (itemIni == "sim")
                    {
                        itemIni = "Bomba Negra";
                    }
                    else
                    {
                        goto teste;
                    }
                    break;
                case '3':
                    Console.WriteLine(" Então você escolhe o Osso do regresso,o item de retornar a qualquer lugar já passado.... tem certeza ? ");
                    Console.WriteLine("--------->sim///////////---------->não");
                    itemIni = Console.ReadLine();
                    if (itemIni == "sim")
                    {
                        itemIni = "Osso do regresso";
                    }
                    else
                    {
                        goto teste;
                    }
                    break;
                case '4':
                    Console.WriteLine(" Então você escolhe a coroa de escamas,o estranho item de camuflagem.... tem certeza ? ");
                    Console.WriteLine("--------->sim///////////---------->não");
                    itemIni = Console.ReadLine();
                    if (itemIni == "sim")
                    {
                        itemIni = "Coroa de Escamas";
                    }
                    else
                    {
                        goto teste;
                    }
                    break;
                case '5':

                    Console.WriteLine(" Então você escolhe o Medalhão de prata,o misterioso item de poder desconhecido.... tem certeza ? ");
                    Console.WriteLine("--------->sim///////////---------->não");
                    itemIni = Console.ReadLine();
                    if (itemIni == "sim")
                    {
                        itemIni = "Medalhão de Prata";
                    }
                    else
                    {
                        goto teste;
                    }
                    break;
                default:
                    break;
            }

            /*Personagem cj = new Personagem(nome, idade, peso, sexo, itemIni);
            List<Personagem> PersonagemNovo = new List<Personagem>();
            PersonagemNovo.Add(cj);

            try
            {
                using (TextWriter tw = new StreamWriter("SavedList.txt"))
                    foreach (var item in PersonagemNovo)
                    {
                        tw.WriteLine($" Nome: {item.Nome} \n Idade: {item.Idade} \n Peso: {item.Peso} \n Sexo: {item.Sexo} \n Item Inicial: {item.ItemIni}");
                    }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }*/

            using (Personagem db = new Personagem(nome, idade, peso, sexo, itemIni))
            {
                // Create and save a new Blog
                

                var blog = new Blog { Name = name };
                db.Blogs.Add(blog);
                db.SaveChanges();

                // Display all Blogs from the database
                var query = from b in db.Blogs
                            orderby b.Name
                            select b;
            }
        }

    }
}

