using System;
using System.Collections.Generic;
using System.Text;


namespace ProjetoRPGProver.Classes
{
    public partial class Classes
    

    {
        //public string TipoClasse { get; set; }
        public int Inteligencia { get; set; }
        public int Força { get; set; }
        public int Fe { get; set; }
        public int Vitalidade { get; set; }
        public int Energia { get; set; }
        public int Magia { get; set; }
        public int Defesa { get; set; }
        public int Vigor { get; set; }
        public virtual List<Personagens.Personagens> Perso { get; set; }

        public Classes(int inteligencia, int força, int fe, int vitalidade, int energia, int magia, int defesa, int vigor)
        {
            //TipoClasse = tipoClasse;
            Inteligencia = inteligencia;
            Força = força;
            Fe = fe;
            Vitalidade = vitalidade;
            Energia = energia;
            Magia = magia;
            Defesa = defesa;
            Vigor = vigor;
        }
    }
}
