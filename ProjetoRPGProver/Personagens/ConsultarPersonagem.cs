using ProjetoRPGProver.Contexto;
using ProjetoRPGProver.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Data.SqlClient;
using ProjetoRPGProver.Services;

namespace ProjetoRPGProver.Personagens
{
    public class ConsultarPersonagem
    {
        public static void Consultar()
        {
            string connectionString = @"Data Source=.;Initial Catalog=PersonagemDB;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            ListPersonagem listPersonagens= new ListPersonagem();
            listPersonagens.ListPerso();

            Console.WriteLine("Seus personagens...");
            foreach (var personagem in listPersonagens.PersonagemList)
            {
                Console.WriteLine($"ID: {personagem.ID}| Personagem: {personagem.Nome}| Peso: {personagem.Peso}| Idade: {personagem.Idade}| Sexo: {personagem.Sexo}| Item inicial: {personagem.ItemIni}");
            }


            Console.ReadKey();







            
        }
    }
        




}

