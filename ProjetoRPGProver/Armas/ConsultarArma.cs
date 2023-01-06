using ProjetoRPGProver.Contexto;
using ProjetoRPGProver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoRPGProver.Armas
{
    public class ConsultarArma
    {
        public static void Consultar()
        {
            using (var db = new PersonagemContexto())
            {
                List<Arma> armas = db.Armas.ToList();
                foreach (var item in armas)
                {
                    Console.WriteLine($"\nArma Escolhida: {item.Qual}| Dano: {item.Dano}| Peso: {item.Peso}");

                }
                Console.ReadKey();
            }
        }
    }
}
