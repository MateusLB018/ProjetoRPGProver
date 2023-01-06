using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPGProver.Poderes
{
    public class MenuPoderes
    {
        public static void Menu()
        {
        voltar:
            try
            {
                Console.Clear();
                var Re2 = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("O que fazer quanto aos [blue]seus poderes[/]")
                            .PageSize(10)
                            .MoreChoicesText("[grey]Mova para cima e para baixo para descobrir suas opções[/]")
                            .AddChoices(new[] {
                            "Criar Poderes", "Consultar Poderes","Editar Poderes", "Deletar Poderes","Voltar"
                                    }));
                //Console.WriteLine(" 1-Criar Poderes\n 2-Consultar Poderes\n 3-Editar Poderes\n 4-DeletarPoderes\n 5-Voltar");
                //var Re = Console.ReadKey();

                switch (Re2)
                {
                    case "Criar Poderes":
                        Console.Clear();

                        CriarPoder.Criando();

                        goto voltar;
                    case "Consultar Poderes":
                        Console.Clear();

                        ConsultarPoder.Consultar();

                        goto voltar;
                    case "Editar Poderes":
                        Console.Clear();
                        EdicaoPoder.Editar();

                        goto voltar;
                    case "Deletar Poderes":
                        Console.Clear();
                        DeletarPoder.Deletar();
                        goto voltar;
                    case "Voltar":
                        Console.Clear();

                        break;
                    default:
                        Console.Clear();
                        AnsiConsole.Markup("Comando[underline red]inválido[/] tente novamente....");
                        goto voltar;

                }
            }
            catch (Exception)
            {
                AnsiConsole.Markup("[underline red]Entrada Inválida...aperte enter para tentar novamente[/]"); ;
                Console.ReadLine();
                goto voltar;
            }


        }    
    }
}
                
                
                
            
        
