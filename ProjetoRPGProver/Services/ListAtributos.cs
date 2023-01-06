using Microsoft.Data.SqlClient;
using ProjetoRPGProver.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPGProver.Services
{
    public class ListAtributos
    {


        public SqlConnection ConnectionAtri { get; set; }
        public List<Atributo> AtributoList { get; set; }
        public ListAtributos()
        {

            string connectionString = @"Data Source=.;Initial Catalog=PersonagemDB;Integrated Security=True";
            SqlConnection _listAtri = new SqlConnection(connectionString);
            ConnectionAtri = _listAtri;
        }
        public void ListAtribu()
        {
            ConnectionAtri.Open();
            string displayAtri = "select * from Atributo";
            SqlCommand displayCommand = new SqlCommand(displayAtri, ConnectionAtri);
            SqlDataReader dataReader = displayCommand.ExecuteReader();

            List<Atributo> _atributoList = new List<Atributo>();
            while (dataReader.Read())
            {
                int id = int.Parse(dataReader.GetValue(0).ToString());
                int inteligencia = int.Parse(dataReader.GetValue(1).ToString());
                int forca = int.Parse(dataReader.GetValue(2).ToString());
                int fe = int.Parse(dataReader.GetValue(3).ToString());
                int vitalidade= int.Parse(dataReader.GetValue(4).ToString());
                int energia = int.Parse(dataReader.GetValue(5).ToString());
                int magia = int.Parse(dataReader.GetValue(6).ToString());
                int defesa = int.Parse(dataReader.GetValue(7).ToString());
                int vigor = int.Parse(dataReader.GetValue(8).ToString());

                Atributo arrayAtributo = new Atributo(id, inteligencia, forca, fe, vitalidade, energia, magia, defesa, vigor);
                _atributoList.Add(arrayAtributo);
            }
            AtributoList = _atributoList;
            ConnectionAtri.Close();
        }

    }
}