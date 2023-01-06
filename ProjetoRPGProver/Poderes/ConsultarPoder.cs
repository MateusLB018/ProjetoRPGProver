using ProjetoRPGProver.Contexto;
using ProjetoRPGProver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoRPGProver.Poderes
{
    public class ConsultarPoder
    {
        public static void Consultar()
        {
            using (var db = new PersonagemContexto())
            {
                List<Poder> poderes = db.Poderes.ToList();
                foreach (var item in poderes)
                {
                    Console.WriteLine($"Poder escolhido: {item.Pod}");

                }

                Console.ReadKey();
            }

        }
    }
}

