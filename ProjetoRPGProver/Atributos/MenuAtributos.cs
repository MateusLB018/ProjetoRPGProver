using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPGProver.Atributos
{
    public class MenuAtributos
    {
        public static void Menu()
        {
        voltar:
            try
            {
                Console.Clear();
                Console.Clear();
                var Re2 = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("O que fazer quanto aos [blue]seus atributos[/]")
                            .PageSize(10)
                            .MoreChoicesText("[grey]Mova para cima e para baixo para descobrir suas opções[/]")
                            .AddChoices(new[] {
                            "Criar Atributos", "Consultar Atributos","Editar Atributos", "Deletar Atributos","Voltar"
                                    }));
                //Console.WriteLine(" 1-Criar atributos\n 2-Consultar atributos\n 3-Editar Atributos\n 4-Deletar Atributos\n 5-voltar");
                //var Re = Console.ReadKey();

                switch (Re2)
                {
                    case "Criar Atributos":
                        Console.Clear();

                        CriarAtributos.Criando();


                        goto voltar;
                    case "Consultar Atributos":
                        Console.Clear();

                        ConsultarAtributo.Consultar();

                        goto voltar;
                    case "Editar Atributos":
                        Console.Clear();
                        EdicaoAtributo.Editar();

                        goto voltar;
                    case "Deletar Atributos":
                        Console.Clear();
                        DeletarAtributos.Deletar();
                        goto voltar;
                    case "Voltar":
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        AnsiConsole.Markup("[underline red]Entrada Inválida...aperte enter para tentar novamente[/]");
                        goto voltar;
                }
            }
            catch (Exception)
            {
                AnsiConsole.Markup("[underline red]Entrada Inválida...aperte enter para tentar novamente[/]");
                Console.ReadLine();
                goto voltar;
            }
            
        }
    }
}

