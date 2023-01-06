using Microsoft.Data.SqlClient;
using ProjetoRPGProver.Services;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPGProver.Armas
{
    public class DeletarArma
    {
        
        public static void Deletar()
        {
        nice:
            try
            {
                string connectionString = @"Data Source=.;Initial Catalog=PersonagemDB;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                ListArma listArmas = new ListArma();
                listArmas.ListArm();

                AnsiConsole.Markup("Digite o [red]ID sua arma [/] para deletar ou 0 para voltar:\n");
                //Console.WriteLine("Digite o ID sua arma para deletar ou 0 para voltar:");
                foreach (var arma in listArmas.ArmaList)
                {
                    Console.WriteLine($"ID: {arma.ID}| Dano da Arma: {arma.Dano}| Nome da arma {arma.Qual}| Peso da arma: {arma.Peso}");
                }

                int armaID = Convert.ToInt32(Console.ReadLine());


                sqlConnection.Open();
                string deleteQuerry = $"Delete FROM Armas WHERE id = {armaID}";
                SqlCommand deleteCommand = new SqlCommand(deleteQuerry, sqlConnection);
                deleteCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception)
            {
                AnsiConsole.Markup("[underline]Entrada Inválida...aperte enter para tentar novamente[/]");
                Console.ReadLine();
                goto nice;
            }
        }
    }
}
