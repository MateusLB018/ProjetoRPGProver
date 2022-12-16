using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace ProjetoRPGProver.Models
{
    public class Personagem
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public double Peso { get; set; }
        public string Sexo { get; set; }
        public string ItemIni { get; set; }

       // public virtual List<Classes.Classes> Classe { get; set; }

        public Personagem(string nome, int idade, double peso, string sexo, string itemIni)
        {
            Nome = nome;
            Idade = idade;
            Peso = peso;
            Sexo = sexo;
            ItemIni = itemIni;
        }
       
    }
}
