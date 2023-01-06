using Microsoft.Data.SqlClient;
using ProjetoRPGProver.Contexto;
using ProjetoRPGProver.Models;
using ProjetoRPGProver.Services;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoRPGProver.Poderes
{
    public class EdicaoPoder
    {
        public static void Editar()
        {
        restartEditArmad:
            Console.Clear();
            string connectionString = @"Data Source=.;Initial Catalog=PersonagemDB;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            ListPoder listPod = new ListPoder();
            listPod.ListPod();

            AnsiConsole.Markup("Digite [red]0[/] para voltar...\n");
            AnsiConsole.Markup("Digite o ID seu poder para editar:\n");
            //Console.WriteLine("Digite o ID seu poder para editar:");
            foreach (var item in listPod.PoderList)
            {
                //Console.WriteLine($"ID: {item.ID} | poder: {item.Pod}");
                AnsiConsole.Markup($"ID: {item.ID} | poder: {item.Pod}\n");
            }
            try
            {
                int PodPick = int.Parse(Console.ReadLine());
                if (PodPick == 0) { return; }
                var pode = listPod.PoderList.FirstOrDefault(x => x.ID == PodPick);
                if (pode != null)
                {
                restartArmad:
                    Console.Clear();

                    //Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine();
                    AnsiConsole.Markup("Digite [red]0[/] para voltar...\n");
                    Console.WriteLine();
                    //Console.ForegroundColor = ConsoleColor.Yellow;
                    //Console.WriteLine();
                    AnsiConsole.Markup($"\nPoder: {pode.Pod}\n");


                    /* Console.WriteLine();
                     Console.WriteLine("Digite o Número do Item que deseja Editar:");
                     Console.WriteLine("1-Poder"); 
                     Console.WriteLine();*/
                    sqlConnection.Open();
                    AnsiConsole.Markup("Digite o novo [blue] poder[/]:\n ");
                    //Console.WriteLine();
                    string pod = pode.Pod;
                    pod = Console.ReadLine();
                    if (pod == "0") { return; }
                    if (string.IsNullOrWhiteSpace(pod))
                    {
                        AnsiConsole.Markup("Você [underline red]DEVE[/] escolher um poder....\n ");
                        
                        sqlConnection.Close();
                        Console.ReadLine();
                        goto restartArmad;
                    }
                    string updateQuerry1 = $"UPDATE Poderes SET pod = '{pod}' WHERE id = {pode.ID}";
                    SqlCommand updateCommand1 = new SqlCommand(updateQuerry1, sqlConnection);
                    updateCommand1.ExecuteNonQuery();
                    Console.WriteLine("Poder atualizado... Aperte Enter para continuar.");
                    sqlConnection.Close();
                    Console.ReadLine();
                    goto restartEditArmad;
                }
            }
            catch (Exception)
            {
                //Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                AnsiConsole.Markup("[underline red]Entrada Inválida...aperte enter para tentar novamente[/]");
                // Console.ResetColor();
                Console.ReadLine();
                goto restartEditArmad;
            }
        }
    }
}
//                    /*var funItem = Console.ReadKey();
//                    switch (funItem.KeyChar)
//                    {
//                        case '1':
//                            Console.WriteLine(" - Digite o novo poder: ");
//                            string pod = pode.Pod;
//                            pod = Console.ReadLine();
//                            if (pod == "0") { return; }
//                            if (string.IsNullOrWhiteSpace(pod))
//                            {
//                                Console.WriteLine("o Nome da armadura não pode estar em Branco....");
//                                sqlConnection.Close();
//                                Console.ReadLine();
//                                goto restartArmad;
//                            }
//                            string updateQuerry1 = $"UPDATE Poderes SET qual = '{pod}' WHERE id = {pode.ID}";
//                            SqlCommand updateCommand1 = new SqlCommand(updateQuerry1, sqlConnection);
//                            updateCommand1.ExecuteNonQuery();
//                            Console.WriteLine("Nome atualizado... Aperte Enter para continuar.");
//                            sqlConnection.Close();
//                            Console.ReadLine();
//                            goto restartEditArmad;

                        

//                        case '0':
//                            goto restartEditArmad;

//                        default:
//                            Console.WriteLine();
//                            Console.WriteLine("inválido.... Aperte Enter e tente novamente.");
//                            sqlConnection.Close();
//                            Console.ReadLine();
//                            goto restartArmad;

//                    }
//                }
//                else
//                {
//                    //Console.ForegroundColor = ConsoleColor.Red;
//                    Console.WriteLine();
//                    Console.WriteLine("O ID digitado é invalido... Aperte Enter e tente novamente.");
//                    //Console.ResetColor();
//                    Console.ReadLine();
//                    goto restartEditArmad;
//                }
//            }
//            catch (Exception)
//            {
//                //Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine();
//                Console.WriteLine("Digite apenas números. Aperte Enter e tente novamente.");
//                // Console.ResetColor();
//                Console.ReadLine();
//                goto restartEditArmad;
//            }

//        }
//    }
//}

