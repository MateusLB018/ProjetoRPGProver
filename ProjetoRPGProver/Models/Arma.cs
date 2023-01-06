using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjetoRPGProver.Models
{
    public class Arma
    {
        public Arma(int iD, int dano, int peso, string qual)
        {
            ID = iD;
            Dano = dano;
            Peso = peso;
            Qual = qual;
        }

        public int ID { get; set; }
        public int Dano { get; set; }
        public int Peso { get; set; }
        public string Qual { get; set; }

    }
}
