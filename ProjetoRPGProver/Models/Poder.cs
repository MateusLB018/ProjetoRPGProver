using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjetoRPGProver.Models
{
    public partial class Poder
    {
        public Poder(int iD, string pod)
        {
            ID = iD;
            Pod = pod;
        }

        public int ID { get; set; }
        public string Pod { get; set; }
    }
}
