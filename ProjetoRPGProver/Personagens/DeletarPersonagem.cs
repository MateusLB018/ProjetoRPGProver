using Microsoft.Data.SqlClient;
using ProjetoRPGProver.Contexto;
using ProjetoRPGProver.Models;
using ProjetoRPGProver.Services;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPGProver.Personagens
{
    public class DeletarPersonagem
    {
        public static void Deletar()
        {
            nice:
            try
            {
                string connectionString = @"Data Source=.;Initial Catalog=PersonagemDB;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                ListPersonagem listPersonagens = new ListPersonagem();
                listPersonagens.ListPerso();

                AnsiConsole.Markup("Digite o [red]ID sua classe(seus atributos)[/] para deletar:\n");
                //Console.WriteLine("Digite o ID sua classe(seus atributos) para deletar:");
                foreach (var personagem in listPersonagens.PersonagemList)
                {
                    Console.WriteLine($"ID: {personagem.ID}| Personagem: {personagem.Nome}| Idade: {personagem.Idade}| Idade: {personagem.Idade}| Sexo: {personagem.Sexo}| Defesa: {personagem.ItemIni}");
                }

                int personagemID = Convert.ToInt32(Console.ReadLine());


                sqlConnection.Open();
                string deleteQuerry = $"Delete FROM Personagem WHERE id = {personagemID}";
                SqlCommand deleteCommand = new SqlCommand(deleteQuerry, sqlConnection);
                deleteCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch
            {
                AnsiConsole.Markup("[underline red]Entrada Inválida...aperte enter para tentar novamente[/]");
                Console.ReadLine();
                goto nice;
            }
        }
    }
}
