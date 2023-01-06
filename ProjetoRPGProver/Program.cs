using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using ProjetoRPGProver.Models;
using System.Data.Entity;
using ProjetoRPGProver.Personagens;
using System.Drawing;
using System.Media;

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



            string logo = @"
                                                                  |\                     /)
                                                                  /\_\\__               (_//
                                                                 |   `>\-`     _._       //`)
                                                                  \ /` \\  _.-`:::`-._  //
                                                                  `     \|`    :::    `|/
                                                                         |     :::     |
                                                                         |.....:::.....|
                                                                         |:::::::::::::|
                                                                         |     :::     |
                                                                         \     :::     /
                                                                          \    :::    /
                                                                           `-. ::: .-'
                                                                            //`:::`\\
                                                                           //   '   \\
                                                                          |/         \\";
            Console.WriteLine(start);
            Console.WriteLine(logo);
            Console.WriteLine("                                                                     Pressione qualquer tecla "); ;


            

            

            while (Console.ReadKey(true).Key != ConsoleKey.Backspace)
            {
            voltar:
                try
                {
                    Console.Clear();
                    
                    var Re2 = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Selecione [blue]sua ação[/]")
                        .PageSize(10)
                        .MoreChoicesText("[grey]Mova para cima e para baixo para descobrir suas opções[/]")
                        .AddChoices(new[] {
                            "Armas", "Atributos","Poderes","Armaduras","Personagem","Finalizar"
                                }));
                    //Console.WriteLine(" 1-Personagem\n 2-Atributos\n 3-Poderes\n 4-Armaduras\n 5-Armas\n 6-finalizar");
                    //var Re = Console.ReadKey();

                    switch (Re2)
                    {
                        case "Armas":
                            
                            Console.Clear();
                            Armas.MenuArma.Menu();
                            

                            goto voltar;
                        case "Atributos":
                            Console.Clear();
                            Atributos.MenuAtributos.Menu();
                            goto voltar;
                        case "Poderes":
                            Console.Clear();
                            Poderes.MenuPoderes.Menu();
                            goto voltar;
                        case "Armaduras":
                            Console.Clear();
                            Armaduras.MenuArmaduras.Menu();
                            goto voltar;
                        case "Personagem":
                            Console.Clear();
                            MenuPersonagem.Menu();
                            goto voltar;
                        case "Finalizar":
                            Console.Clear();
                            AnsiConsole.Markup("[blue]Até logo aventureiro....[/] ");
                            //Console.WriteLine("Até logo aventureiro....");
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Comando inválido tente novamente....");
                            goto voltar;
                    }
                }
                catch(Exception)
                {
                    AnsiConsole.Markup("[underline]Entrada Inválida...aperte enter para tentar novamente[/]");
                    Console.ReadLine();
                    goto voltar;
                }
                
                AnsiConsole.Markup("\nPressione [underline red]Back[/] para sair ou qualquer outra tecla para voltar...");
            }





        }

    }
}
