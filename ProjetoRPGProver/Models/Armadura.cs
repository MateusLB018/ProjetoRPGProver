using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjetoRPGProver.Models
{
    public class Armadura
    {
        public Armadura(int iD, string qual, int danoAbs, int peso)
        {
            ID = iD;
            Qual = qual;
            DanoAbs = danoAbs;
            Peso = peso;
        }

        public int ID { get; set; }
        public string Qual { get; set; }
        public int DanoAbs { get; set; }
        public int Peso { get; set; }
    }
}
