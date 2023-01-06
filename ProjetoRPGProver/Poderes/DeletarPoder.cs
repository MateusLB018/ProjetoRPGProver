using Microsoft.Data.SqlClient;
using ProjetoRPGProver.Services;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPGProver.Poderes
{
    public partial class DeletarPoder
    {
        public static void Deletar()
        {teste:
            try
            {
                string connectionString = @"Data Source=.;Initial Catalog=PersonagemDB;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                ListPoder listPoderes = new ListPoder();
                listPoderes.ListPod();

                AnsiConsole.Markup("Digite o [red]ID[/] de sua classe(seus atributos)\n");
                //Console.WriteLine("Digite o ID sua classe (seus atributos) para deletar ou 0 para voltar:");
                foreach (var poder in listPoderes.PoderList)
                {
                    AnsiConsole.Markup($"\nID: {poder.ID}| Poder de: {poder.Pod}");
                    //Console.WriteLine($"ID: {poder.ID}| Poder de: {poder.Pod}");
                }

                int poderID = Convert.ToInt32(Console.ReadLine());


                sqlConnection.Open();
                string deleteQuerry = $"Delete FROM Poderes WHERE id = {poderID}";
                SqlCommand deleteCommand = new SqlCommand(deleteQuerry, sqlConnection);
                deleteCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception)
            {
                AnsiConsole.Markup("[underline red]Entrada Inválida...aperte enter para tentar novamente[/]");
                Console.ReadLine();
                goto teste;
            }
        }
    }
}
