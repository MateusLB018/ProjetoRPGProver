using Microsoft.Data.SqlClient;
using OpenQA.Selenium;
using ProjetoRPGProver.Contexto;
using ProjetoRPGProver.Models;
using ProjetoRPGProver.Services;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPGProver.Armaduras
{
    public partial class CriarArmadura
    {
       
        public static void Criando()
        {
        
            Console.Clear();
            string connectionString = @"Data Source=.;Initial Catalog=PersonagemDB;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            ListArmadura ListaCria = new ListArmadura();
            ListaCria.ListArmad();

        teste:
            try
            {
                int peso = 0, danoAbs = 0;
                string qual = "";
                Console.Clear();
                var Re3 = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Antes de tudo...deseja criar uma armadura do zero ou utilizar uma pré existente ?")
                        .PageSize(10)
                        .MoreChoicesText("[grey]Mova para cima e para baixo para descobrir suas opções[/]")
                        .AddChoices(new[] {
                            "Criar", "Utilizar existentes"
                                }));
                if (Re3 == "Criar")
                {teste2:
                    try
                    {
                        
                        AnsiConsole.Markup("Muito bem....Escolha o nome de sua armadura\n");
                        qual = Console.ReadLine();
                    novamente8:
                        AnsiConsole.Markup("Agora Escolha O [purple]peso[/] de sua armadura\n");
                        peso = Convert.ToInt32(Console.ReadLine());
                        if (peso < 0)
                        {
                            Console.WriteLine("Inválido, digite novamente...");
                            goto novamente8;
                            
                        }
                    novamente9:
                        AnsiConsole.Markup("Finalmente... Escolha a [purple]defesa[/] de sua armadura\n");
                        danoAbs = Convert.ToInt32(Console.ReadLine());
                        if (danoAbs < 0)
                        {
                            Console.WriteLine("Inválido, digite novamente...");
                            goto novamente9;
                            
                            
                        }
                        goto fim;
                    }
                    catch (Exception)
                    {
                        AnsiConsole.Markup("[underline red] Inválido,aperte enter e tente novamente");
                        Console.ReadLine();
                        goto teste2;
                    }
                }
                else { 
                //string answ = "";
                
                //Console.Clear();
                //Console.WriteLine("Escolha sua armadura:");
                //Console.WriteLine("1-Manto de Mago ");
                //Console.WriteLine("2-Armadura de Samurai ");
                //Console.WriteLine("3-Armadura de cavaleiro real");
                //Console.WriteLine("4-Manto de Assassino");
                //Console.WriteLine("5-Manto de Clérigo");
                //Console.WriteLine("0-Para voltar");

                //var result = Console.ReadKey();
                var Re2 = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Selecione [blue]sua armadura[/]")
                        .PageSize(10)
                        .MoreChoicesText("[grey]Mova para cima e para baixo para descobrir suas opções[/]")
                        .AddChoices(new[] {
                            "Manto de Mago", "Armadura de Samurai","Armadura de Cavaleiro Real","Manto de Assassino","Manto de Clérigo","Voltar"
                                }));


                    switch (Re2)
                    {
                        case "Manto de Mago":

                            AnsiConsole.Markup("Você escolheu [purple]Manto de Mago[/], o manto leve e mágico com defesa de 250 e peso 10kg....\n");
                            var nice = AnsiConsole.Confirm("Tem certeza?");

                            if (nice == true)
                            {
                                peso = 10;
                                danoAbs = 250;
                                qual = "Manto de Mago";

                            }
                            else
                            {
                                goto teste;
                            }
                            break;
                        case "Armadura de Samurai":

                            AnsiConsole.Markup("Você escolheu [purple]Armadura de Samurai[/], A armadura oriental de Defesa de dano de 450 e peso 22kg....\n");
                            var nice2 = AnsiConsole.Confirm("Tem certeza?");

                            if (nice2 == true)
                            {
                                peso = 450;
                                danoAbs = 22;
                                qual = "Armadura de Samurai";

                            }
                            else
                            {
                                goto teste;
                            }
                            break;
                        /*case "Armadura de Samurai":
                        novamente2:

                            //Console.WriteLine("Você escolheu a , A armadura oriental de Defesa de dano de 450 e peso 22kg....tem certeza ?");
                            Console.WriteLine("s------>n----->");
                            answ = Console.ReadLine();
                            if (answ == "s" || answ == "S")
                            {
                                peso = 450;
                                danoAbs = 22;
                                qual = "Armadura de Samurai";
                            }
                            else if (answ == "n" || answ == "N")
                            {
                                goto teste;
                            }
                            else
                            {
                                Console.WriteLine("Inválido tente novamente.....");
                                goto novamente2;
                            }
                            break;*/
                        case "Armadura de Cavaleiro Real":

                            AnsiConsole.Markup("Você escolheu [purple]Armadura de Cavaleiro Real[/], A armadura pesada e lenta mas com uma grande defesa de 750 e peso 32kg....\n");
                            var nice3 = AnsiConsole.Confirm("Tem certeza?");

                            if (nice3 == true)
                            {
                                peso = 32;
                                danoAbs = 750;
                                qual = "Armadura de Cavaleiro Real";

                            }
                            else
                            {
                                goto teste;
                            }
                            break;
                        //case "Armadura de cavaleiro real":
                        //novamente3:
                        //    //Console.WriteLine("Você escolheu a armadura de cavaleiro real, A armadura pesada e lenta mas com uma grande defesa de 750 e peso 32kg....tem certeza ?");
                        //    Console.WriteLine("s------>n----->");
                        //    answ = Console.ReadLine();
                        //    if (answ == "s" || answ == "S")
                        //    {
                        //        peso = 32;
                        //        danoAbs = 750;
                        //        qual = "Armadura de Cavaleiro real";

                        //    }
                        //    else if (answ == "n" || answ == "N")
                        //    {
                        //        goto teste;
                        //    }
                        //    else
                        //    {
                        //        Console.WriteLine("Inválido tente novamente.....");
                        //        goto novamente3;
                        //    }
                        //    break;
                        case "Manto de Assassino":

                            AnsiConsole.Markup("Você escolheu [purple]Manto de Assassino[/], O confortável e furtivo manto encapuzado com defesa de 250 e peso 9kg....\n");
                            var nice4 = AnsiConsole.Confirm("Tem certeza?");

                            if (nice4 == true)
                            {
                                peso = 9;
                                danoAbs = 250;
                                qual = "Manto de Assassino";

                            }
                            else
                            {
                                goto teste;
                            }
                            break;
                        //case "Manto de Assassino":
                        //novamente4:
                        //    //Console.WriteLine("Você escolheu o Manto de Assassino, O confortável e furtivo manto encapuzado com defesa de 250 e peso 9kg....tem certeza ?");
                        //    Console.WriteLine("s------>n----->");
                        //    answ = Console.ReadLine();
                        //    if (answ == "s" || answ == "S")
                        //    {
                        //        peso = 9;
                        //        danoAbs = 250;
                        //        qual = "Manto de Assassino";

                        //    }
                        //    else if (answ == "n" || answ == "N")
                        //    {
                        //        goto teste;
                        //    }
                        //    else
                        //    {
                        //        Console.WriteLine("Inválido tente novamente.....");
                        //        goto novamente4;
                        //    }
                        //    break;
                        case "Manto de Clérigo":

                            AnsiConsole.Markup("Você escolheu [purple]Manto de Clérigo[/], O manto sagrado e leve com defesa de 200 e peso 6kg....\n");
                            var nice5 = AnsiConsole.Confirm("Tem certeza?");

                            if (nice5 == true)
                            {
                                peso = 9;
                                danoAbs = 250;
                                qual = "Manto de Assassino";

                            }
                            else
                            {
                                goto teste;
                            }
                            break;

                        //case "Manto de Clérigo":
                        //novamente5:
                        //    Console.WriteLine("Você escolheu o Manto de Clérigo, O manto sagrado e leve com defesa de 200 e peso 6kg....tem certeza ?");
                        //    Console.WriteLine("s------>n----->");
                        //    answ = Console.ReadLine();
                        //    if (answ == "s" || answ == "S")
                        //    {
                        //        peso = 6;
                        //        danoAbs = 200;
                        //        qual = "Manto de Clérigo";

                        //    }
                        //    else if (answ == "n" || answ == "N")
                        //    {
                        //        goto teste;
                        //    }
                        //    else
                        //    {
                        //        Console.WriteLine("Inválido tente novamente.....");
                        //        goto novamente5;
                        //    }
                        //    break;
                        case "Voltar":
                            return;
                        default:
                            AnsiConsole.Markup("[underline]Entrada Inválida...aperte enter para tentar novamente[/]");
                            Console.ReadLine();
                            goto teste;
                    }


                }
                fim:
                sqlConnection.Open();
                string insertQuerry = $"INSERT INTO Armaduras(danoAbs, peso, qual)VALUES('{danoAbs}','{peso}','{qual}')";
                SqlCommand insertCommand = new SqlCommand(insertQuerry, sqlConnection);
                insertCommand.ExecuteNonQuery();
                Console.WriteLine("Armadura selecionado.... Aperte Enter para retornar....");
                sqlConnection.Close();
                Console.ReadLine();
            }
            catch (Exception)
            {

                AnsiConsole.Markup("[underline]Entrada Inválida...aperte enter para tentar novamente[/]");
                Console.ReadLine();
                goto teste;
            }
            

        }
    }
}
