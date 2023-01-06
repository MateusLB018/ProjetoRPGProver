using Microsoft.Data.SqlClient;
using ProjetoRPGProver.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPGProver.Services
{
    public class ListPersonagem
    {


        public SqlConnection ConnectionPer { get; set; }
        public List<Personagem> PersonagemList { get; set; }
        public ListPersonagem()
        {

            string connectionString = @"Data Source=.;Initial Catalog=PersonagemDB;Integrated Security=True";
            SqlConnection _listPer = new SqlConnection(connectionString);
            ConnectionPer = _listPer;
        }
        public void ListPerso()
        {
            ConnectionPer.Open();
            string displayPer = "select * from Personagem";
            //select c.*, f.nome from  Cliente c, Funcionario f where f.id = c.fun_id
            //string displayPer = "select p.*, a.Qual from Armas a, amd.Qual from Armaduras amd, pod.Pod from Poderes pod, at.* from Atributo at, from personagem p where ID = p.ArmaID,ID = p.ArmaduraID,ID = p.PoderID,ID = p.AtributoID";
            SqlCommand displayCommand = new SqlCommand(displayPer, ConnectionPer);
            SqlDataReader dataReader = displayCommand.ExecuteReader();

            List<Personagem> _personagemList = new List<Personagem>();
            while (dataReader.Read())
            {
                int id = int.Parse(dataReader.GetValue(0).ToString());
                string nome = dataReader.GetValue(1).ToString();
                int idade = int.Parse(dataReader.GetValue(2).ToString());
                int peso = int.Parse(dataReader.GetValue(3).ToString());
                string sexo = dataReader.GetValue(4).ToString();
                string itemIni = dataReader.GetValue(5).ToString();
                int armaID = int.Parse(dataReader.GetValue(6).ToString());
                int armaduraID = int.Parse(dataReader.GetValue(7).ToString());
                int poderID = int.Parse(dataReader.GetValue(8).ToString());
                int atributoID = int.Parse(dataReader.GetValue(9).ToString());


                Personagem arrayPersonagem = new Personagem(id, nome, idade, peso, sexo, itemIni, armaID, armaduraID, poderID, atributoID);
                _personagemList.Add(arrayPersonagem);
            }
            PersonagemList = _personagemList;
            ConnectionPer.Close();
        }

    }
}