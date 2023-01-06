using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPGProver.Personagens
{
    public class MenuPersonagem
    {
        public static void Menu()
        {
        voltar:
            try
            {
                Console.Clear();
                var Re2 = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("O que fazer quanto a [underline blue]Você? [/]")
                            .PageSize(10)
                            .MoreChoicesText("[grey]Mova para cima e para baixo para descobrir suas opções[/]")
                            .AddChoices(new[] {
                            "Criar Personagem", "Consultar Personagem","Editar Personagem", "Deletar Personagem","Voltar"
                                    }));
                /*Console.WriteLine(" 1-Criar Personagem\n 2-Consultar Personagem\n 3-Editar Personagem\n 4-Deletar Personagem\n 5-Voltar");
                var Re = Console.ReadKey();*/

                switch (Re2)
                {
                    case "Criar Personagem":
                        Console.Clear();
                        Personagens.Criando();

                        goto voltar;
                    case "Consultar Personagem":
                        Console.Clear();
                        ConsultarPersonagem.Consultar();

                        goto voltar;
                    case "Editar Personagem":
                        Console.Clear();
                        Personagen.Editar();

                        goto voltar;
                    case "Deletar Personagem":
                        Console.Clear();
                        DeletarPersonagem.Deletar();
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
                AnsiConsole.Markup("[underline red]Entrada Inválida...aperte enter para tentar novamente[/]");
                Console.ReadLine();
                goto voltar;
            }
            
        }
    }
}
