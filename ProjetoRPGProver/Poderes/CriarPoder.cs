using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using ProjetoRPGProver.Contexto;
using ProjetoRPGProver.Models;
using ProjetoRPGProver.Services;
using Spectre.Console;

namespace ProjetoRPGProver.Poderes
{
    public partial class CriarPoder
    {
        public static void Criando()
        {
        teste:
            try
            {
            
                string connectionString = @"Data Source=.;Initial Catalog=PersonagemDB;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                ListPoder ListaCria = new ListPoder();
                ListaCria.ListPod();

                Console.Clear();
            
                AnsiConsole.Markup("Qual [blue] poder [/] deseja ? Seja sábio em sua escolha...\n");
                //Console.WriteLine("Qual poder deseja ? Seja sábio em sua escolha...");
                string pod = Console.ReadLine();
            teste2:
                Console.WriteLine($"Você escolheu {pod}.... "); //tem certeza ?
                var asw = AnsiConsole.Confirm("Tem certeza ?\n");
                
                //string asw = Console.ReadLine();
                if (asw==true)
                {

                    sqlConnection.Open();
                    string insertQuerry = $"INSERT INTO Poderes(pod)VALUES('{pod}')";
                    SqlCommand insertCommand = new SqlCommand(insertQuerry, sqlConnection);
                    insertCommand.ExecuteNonQuery();
                    Console.WriteLine("Poder obtido.... Aperte Enter para retornar....");
                    sqlConnection.Close();
                    Console.ReadLine();
                }
                else 
                {
                    goto teste;
                }
                /*else
                {
                    Console.WriteLine("Comando inválido tente novamente");
                    goto teste2;
                }*/
            }
            catch (Exception)
            {
                Console.WriteLine("Comando Inválido...tente novamente");
                Console.ReadLine();
                goto teste;
            }
        }
    }
}
