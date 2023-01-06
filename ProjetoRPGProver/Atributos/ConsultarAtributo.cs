using Microsoft.Data.SqlClient;
using ProjetoRPGProver.Contexto;
using ProjetoRPGProver.Models;
using ProjetoRPGProver.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoRPGProver.Atributos
{
    public class ConsultarAtributo
    {
        public static void Consultar()
        {
            string connectionString = @"Data Source=.;Initial Catalog=PersonagemDB;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            ListAtributos listAtributos = new ListAtributos();
            listAtributos.ListAtribu();

            Console.WriteLine("Suas classes e atributos...");
            foreach (var atributo in listAtributos.AtributoList)
            {
                Console.WriteLine($"ID: {atributo.ID}| Inteligência: {atributo.Inteligencia}| Força: {atributo.Força}| Fé: {atributo.Fe}| Energia: {atributo.Energia}| Defesa: {atributo.Defesa}| Vitalidade: {atributo.Vitalidade}| Vigor: {atributo.Vigor}| Magia: {atributo.Magia}");
            }

            
            Console.ReadKey();


            

                
            
        }
    }
}
