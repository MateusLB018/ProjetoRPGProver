using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPGProver.Armaduras
{
    public class MenuArmaduras
    {
        public static void Menu()
        {
        voltar:
            try
            {
                
                Console.Clear();
                var Re2 = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("O que fazer quanto a [underline blue]suas armaduras[/]")
                            .PageSize(10)
                            .MoreChoicesText("[grey]Mova para cima e para baixo para descobrir suas opções[/]")
                            .AddChoices(new[] {
                            "Criar Armadura", "Consultar Armadura","Editar Armadura", "Deletar Armadura","Voltar"
                                    }));
                //Console.WriteLine(" 1-Criar Armadura\n 2-Ver Armadura\n 3-EditarArmadura\n 4-DeletarArmadura\n 5-Voltar");
                //var Re = Console.ReadKey();

                switch (Re2)
                {
                    case "Criar Armadura":
                        Console.Clear();

                        CriarArmadura.Criando();


                        goto voltar;
                    case "Consultar Armadura":
                        Console.Clear();

                        ConsultarArmadura.Consultar();
                        goto voltar;
                    case "Editar Armadura":
                        Console.Clear();
                        EdicaoArmadura.Editar();

                        goto voltar;
                    case "Deletar Armadura":
                        Console.Clear();
                        DeletarArmadura.Deletar();
                        goto voltar;
                    case "Voltar":
                        Console.Clear();

                        break;
                    default:
                        Console.Clear();
                        AnsiConsole.Markup("[underline]Entrada Inválida...aperte enter para tentar novamente[/]");
                        goto voltar;
                }
            }
            catch (Exception)
            {
                AnsiConsole.Markup("[underline]Entrada Inválida...aperte enter para tentar novamente[/]");
                Console.ReadLine();
                goto voltar;
            }
            
        }
    }
}
