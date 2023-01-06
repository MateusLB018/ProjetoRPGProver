using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Text;

namespace ProjetoRPGProver.Models
{
    public class Personagem
    {
        public Personagem(int iD, string nome, int idade, int peso, string sexo, string itemIni, int armaID, int armaduraID, int poderID, int atributoID)
        {
            ID = iD;
            Nome = nome;
            Idade = idade;
            Peso = peso;
            Sexo = sexo;
            ItemIni = itemIni;
            ArmaID = armaID;
            ArmaduraID = armaduraID;
            PoderID = poderID;
            AtributoID = atributoID;
        }

        public int ID { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int Peso { get; set; }
        public string Sexo { get; set; }
        public string ItemIni { get; set; }
        public int ArmaID { get; set; }
        public int ArmaduraID { get; set; }
        public int PoderID { get; set; }
        public int AtributoID { get; set; }


    }
}
