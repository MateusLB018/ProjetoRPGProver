using Microsoft.Data.SqlClient;
using ProjetoRPGProver.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPGProver.Services
{
    public class ListPoder
    {
        public SqlConnection ConnectionPod { get; set; }
        public List<Poder> PoderList { get; set; }
        public ListPoder()
        {

            string connectionString = @"Data Source=.;Initial Catalog=PersonagemDB;Integrated Security=True";
            SqlConnection _listPod = new SqlConnection(connectionString);
            ConnectionPod = _listPod;
        }
        public void ListPod()
        {
            ConnectionPod.Open();
            string displayPod = "select * from Poderes";
            SqlCommand displayCommand = new SqlCommand(displayPod, ConnectionPod);
            SqlDataReader dataReader = displayCommand.ExecuteReader();

            List<Poder> _poderList = new List<Poder>();
            while (dataReader.Read())
            {
                int id = int.Parse(dataReader.GetValue(0).ToString());
                string pod = dataReader.GetValue(1).ToString();


                Poder arrayPoder = new Poder(id,pod);
                _poderList.Add(arrayPoder);
            }
            PoderList = _poderList;
            ConnectionPod.Close();
        }

    }
    }

