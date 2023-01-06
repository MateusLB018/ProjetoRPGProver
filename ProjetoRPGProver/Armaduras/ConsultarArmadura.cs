using ProjetoRPGProver.Contexto;
using ProjetoRPGProver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoRPGProver.Armaduras
{
    public class ConsultarArmadura
    {
        public static void Consultar()
        {
            using (var db = new PersonagemContexto())
            {
                List<Armadura> armaduras = db.Armaduras.ToList();
                foreach (var item in armaduras)
                {
                    Console.WriteLine($"Armadura escolhida: {item.Qual}| Absorção de dano: {item.DanoAbs}| Peso da armadura: {item.Peso}");

                }
                Console.ReadKey();
            }

        }
    }
}
