using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjetoDarkSouls.Personagens
{
    public partial class Personagens
    {
        public static void Editar()
        {
            try
            {
                
                StreamWriter sw = new StreamWriter("Personagem.txt");
                sw.WriteLine();

                sw.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);

            }
            finally
            {
                Console.WriteLine("Executing finally block");
            }
        }
    }
}