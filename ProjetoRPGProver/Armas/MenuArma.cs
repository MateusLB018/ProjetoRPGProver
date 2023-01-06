using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPGProver.Armas
{
    public class MenuArma
    {
        public static void Menu()
        {
        voltar:
            try
            {
 
                Console.Clear();
                var Re2 = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("O que fazer quanto a [underline blue]suas armas[/]")
                            .PageSize(10)
                            .MoreChoicesText("[grey]Mova para cima e para baixo para descobrir suas opções[/]")
                            .AddChoices(new[] {
                            "Criar Arma", "Consultar Arma","Editar Arma", "Deletar Arma","Voltar"
                                    }));
                //Console.WriteLine(" 1-Criar Arma\n 2-Ver Arma\n 3-Editar Arma\n 4-Deletar Arma\n 5-Voltar");
                //var Re = Console.ReadKey();

                switch (Re2)
                {
                    case "Criar Arma":
                        Console.Clear();

                        Armas.CriarArma.Criando();

                        goto voltar;
                    case "Consultar Arma":
                        Console.Clear();

                        Armas.ConsultarArma.Consultar();
                        goto voltar;
                    case "Editar Arma":
                        Console.Clear();
                        EdicaoArma.Editar();

                        goto voltar;
                    case "Deletar Arma":
                        Console.Clear();
                        DeletarArma.Deletar();
                        goto voltar;
                    case "Voltar":
                        Console.Clear();

                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Comando inválido tente novamente....");
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

