using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjetoRPGProver.Models
{
    public class Atributo
    {
        public Atributo(int iD, int inteligencia, int força, int fe, int vitalidade, int energia, int magia, int defesa, int vigor)
        {
            ID = iD;
            Inteligencia = inteligencia;
            Força = força;
            Fe = fe;
            Vitalidade = vitalidade;
            Energia = energia;
            Magia = magia;
            Defesa = defesa;
            Vigor = vigor;
        }

        public int ID { get; set; }
        public int Inteligencia { get; set; }
        public int Força { get; set; }
        public int Fe { get; set; }
        public int Vitalidade { get; set; }
        public int Energia { get; set; }
        public int Magia { get; set; }
        public int Defesa { get; set; }
        public int Vigor { get; set; }
    }
}

