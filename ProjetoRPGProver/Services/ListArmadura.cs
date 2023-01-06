using Microsoft.Data.SqlClient;
using ProjetoRPGProver.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPGProver.Services
{
    public class ListArmadura
    {
        public SqlConnection ConnectionArmadura { get; set; }
        public List<Armadura> ArmaduraList { get; set; }
        public ListArmadura()
        {
            string connectionString = @"Data Source=.;Initial Catalog=PersonagemDB;Integrated Security=True";
            SqlConnection _listArmadu = new SqlConnection(connectionString);
            ConnectionArmadura = _listArmadu;
        }

        public void ListArmad()
        {
            ConnectionArmadura.Open();
            string displayArmadura = "select * from Armaduras";
            SqlCommand displayCommand = new SqlCommand(displayArmadura, ConnectionArmadura);
            SqlDataReader dataReader = displayCommand.ExecuteReader();

            List<Armadura> _armaduraList = new List<Armadura>();
            while (dataReader.Read())
            {
                int id = int.Parse(dataReader.GetValue(0).ToString());
                int danoAbs = int.Parse(dataReader.GetValue(1).ToString());
                int peso = int.Parse(dataReader.GetValue(2).ToString());
                string qual = dataReader.GetValue(3).ToString();

               

                Armadura arrayArmadura = new Armadura(id, qual, danoAbs, peso);
                _armaduraList.Add(arrayArmadura);
            }
            ArmaduraList = _armaduraList;
            ConnectionArmadura.Close();
        }
    }
    }

