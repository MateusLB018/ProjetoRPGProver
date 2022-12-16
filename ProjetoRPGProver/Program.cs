using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using ProjetoRPGProver.Classes;
using System.Data.Entity;

using ProjetoRPGProver.Personagens;


namespace ProjetoRPGProver
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //int Re;
            Console.WriteLine("\n\n\n\n\n\n");
            //Console.WriteLine("                                                      --RPG--PROVER--\n");
            string start = @"
      _______   _______    ______         _______   _______    ______   __     __  ________  _______  
     /       \ /       \  /      \       /       \ /       \  /      \ /  |   /  |/        |/       \ 
     $$$$$$$  |$$$$$$$  |/$$$$$$  |      $$$$$$$  |$$$$$$$  |/$$$$$$  |$$ |   $$ |$$$$$$$$/ $$$$$$$  |
     $$ |__$$ |$$ |__$$ |$$ | _$$/       $$ |__$$ |$$ |__$$ |$$ |  $$ |$$ |   $$ |$$ |__    $$ |__$$ |
     $$    $$< $$    $$/ $$ |/    |      $$    $$/ $$    $$< $$ |  $$ |$$  \ /$$/ $$    |   $$    $$< 
     $$$$$$$  |$$$$$$$/  $$ |$$$$ |      $$$$$$$/  $$$$$$$  |$$ |  $$ | $$  /$$/  $$$$$/    $$$$$$$  |
     $$ |  $$ |$$ |      $$ \__$$ |      $$ |      $$ |  $$ |$$ \__$$ |  $$ $$/   $$ |_____ $$ |  $$ |
     $$ |  $$ |$$ |      $$    $$/       $$ |      $$ |  $$ |$$    $$/    $$$/    $$       |$$ |  $$ |
     $$/   $$/ $$/        $$$$$$/        $$/       $$/   $$/  $$$$$$/      $/     $$$$$$$$/ $$/   $$/ 



 ";
            Console.WriteLine(start);
            Console.WriteLine("                                             Pressione qualquer tecla "); ;
            /* Console.ReadKey(true);
             Console.Clear();

             var fruit = AnsiConsole.Prompt(
             new SelectionPrompt<string>()
             .Title("Escolha [green]seu destino[/]:")
             .PageSize(10)
             .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
             .AddChoices(new[] {
                 "Criar Novo Personagem", "Editar Personagem", "Finalizar Criação",

             }));*/

            while (Console.ReadKey(true).Key != ConsoleKey.Backspace)
            {

                Console.Clear();
                Console.WriteLine(" 1-Criar Novo Personagem\n 2-Editar Personagem\n 3-Deletar Personagem\n 4-Finalizar Criação\n");
                var Re = Console.ReadKey();

                switch (Re.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        Personagens.Personagens.Criando();
                        Classes.Classes.Criando();
                        /*CriandoArma();
                        CriandoArmadura();
                        CriandoSkill();*/

                        break;
                    case '2':
                        Console.Clear();
                        //EditarPerso();
                        break;
                    case '3':
                        Console.Clear();
                        //DeletarPerso();
                        break;
                    case '4':
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        break;
                }

                Console.Write("\nPressione 'Back' para sair ...");
            }





        }
       
    }
}
