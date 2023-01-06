using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjetoRPGProver.Contexto;
using ProjetoRPGProver.Models;
using ProjetoRPGProver.Services;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPGProver.Atributos
{
    public class DeletarAtributos
    {
        public static void Deletar()
        {
            nice:
            try
            {
                string connectionString = @"Data Source=.;Initial Catalog=PersonagemDB;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                ListAtributos listAtributos = new ListAtributos();
                listAtributos.ListAtribu();

                AnsiConsole.Markup("Digite o [red]ID sua classe[/] (seus atributos) para deletar:\n");
                //Console.WriteLine("Digite o ID sua classe(seus atributos) para deletar:");
                foreach (var atributo in listAtributos.AtributoList)
                {
                    Console.WriteLine($"ID: {atributo.ID}| Inteligência: {atributo.Inteligencia}| Força: {atributo.Força}| Fé: {atributo.Fe}| Energia: {atributo.Energia}| Defesa: {atributo.Defesa}| Vitalidade: {atributo.Vitalidade}| Vigor: {atributo.Vigor}| Magia: {atributo.Magia}");
                }

                int atributoID = Convert.ToInt32(Console.ReadLine());


                sqlConnection.Open();
                string deleteQuerry = $"Delete FROM Atributo WHERE id = {atributoID}";
                SqlCommand deleteCommand = new SqlCommand(deleteQuerry, sqlConnection);
                deleteCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception)
            {
                AnsiConsole.Markup("[underline red]Entrada Inválida...aperte enter para tentar novamente[/]");
                Console.ReadLine();
                goto nice;

            }

            
            

        }
    }
}
