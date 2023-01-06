using Microsoft.Data.SqlClient;
using ProjetoRPGProver.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPGProver.Services
{
    public class ListArma
    {
        public SqlConnection ConnectionArma { get; set; }
        public List<Arma> ArmaList { get; set; }
        public ListArma()
        {
            string connectionString = @"Data Source=.;Initial Catalog=PersonagemDB;Integrated Security=True";
            SqlConnection _listArma = new SqlConnection(connectionString);
            ConnectionArma = _listArma;
        }
        public void ListArm()
        {
            ConnectionArma.Open();
            string displayArma = "select * from Armas";
            SqlCommand displayCommand = new SqlCommand(displayArma, ConnectionArma);
            SqlDataReader dataReader = displayCommand.ExecuteReader();

            List<Arma> _armaList = new List<Arma>();
            while (dataReader.Read())
            {
                int id = int.Parse(dataReader.GetValue(0).ToString());
                int dano = int.Parse(dataReader.GetValue(1).ToString());
                int peso = int.Parse(dataReader.GetValue(2).ToString());
                string qual = dataReader.GetValue(3).ToString();

                Arma arrayArma = new Arma(id, dano, peso, qual);
                _armaList.Add(arrayArma);
            }
            ArmaList = _armaList;
            ConnectionArma.Close();
        }
    }
}
