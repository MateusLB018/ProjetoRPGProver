using Microsoft.Data.SqlClient;
using ProjetoRPGProver.Services;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPGProver.Armaduras
{
    public class DeletarArmadura
    {
        public static void Deletar()
        {
            teste:
            string connectionString = @"Data Source=.;Initial Catalog=PersonagemDB;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            ListArmadura listArmadura = new ListArmadura();
            listArmadura.ListArmad();
            try
            {


                AnsiConsole.Markup("Digite o [red]ID sua armadura[/] para deletar ou 0 para voltar:\n");
                //Console.WriteLine("Digite o ID sua armadura para deletar ou 0 para voltar:");
                foreach (var armadura in listArmadura.ArmaduraList)
                {
                    Console.WriteLine($"ID: {armadura.ID}| Nome da armadura: {armadura.Qual}| Defesa: {armadura.DanoAbs}| Peso da armadura: {armadura.Peso}");
                }

                int armaduraID = Convert.ToInt32(Console.ReadLine());


                sqlConnection.Open();
                string deleteQuerry = $"Delete FROM Armaduras WHERE id = {armaduraID}";
                SqlCommand deleteCommand = new SqlCommand(deleteQuerry, sqlConnection);
                deleteCommand.ExecuteNonQuery();
                sqlConnection.Close();
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
