using Microsoft.Data.SqlClient;
using ProjetoRPGProver.Contexto;
using ProjetoRPGProver.Models;
using ProjetoRPGProver.Services;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPGProver.Armas
{
    public class CriarArma
    {
        public static void Criando()
        {
            string connectionString = @"Data Source=.;Initial Catalog=PersonagemDB;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            ListArma ListaCria = new ListArma();
            ListaCria.ListArm();

            int peso = 0, dano = 0;
            string qual = "";




        teste:
            Console.Clear();
            try
            {
                Console.Clear();
                var Re3 = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Antes de tudo...deseja criar uma arma do zero ou utilizar uma pré existente ?")
                        .PageSize(10)
                        .MoreChoicesText("[grey]Mova para cima e para baixo para descobrir suas opções[/]")
                        .AddChoices(new[] {
                            "Criar", "Utilizar existentes"
                                }));
                if (Re3 == "Criar")
                {
                    AnsiConsole.Markup("Muito bem....Escolha o [purple]nome[/] da sua arma\n");
                    qual = Console.ReadLine();
                    novamente8:
                    AnsiConsole.Markup("Agora Escolha O [purple]peso[/] da sua arma\n");
                    peso = Convert.ToInt32(Console.ReadLine());
                    if (peso < 0)
                    {
                        goto novamente8;
                        Console.WriteLine("Inválido, digite novamente...");
                        
                    }
                    novamente9:
                    AnsiConsole.Markup("Finalmente... Escolha o [purple]dano[/] da sua arma(não exagere)\n");
                    dano = Convert.ToInt32(Console.ReadLine());
                    if (dano < 0)
                    {

                        Console.WriteLine("Inválido, digite novamente...");
                        
                    }
                    sqlConnection.Open();
                    string insertQuerry = $"INSERT INTO Armas(dano, peso, qual)VALUES('{dano}','{peso}','{qual}')";
                    SqlCommand insertCommand = new SqlCommand(insertQuerry, sqlConnection);
                    insertCommand.ExecuteNonQuery();
                    Console.WriteLine("Arma selecionada.... Aperte Enter para retornar....");
                    sqlConnection.Close();
                    Console.ReadLine();

                }
                else
                {
                    var Re2 = AnsiConsole.Prompt(
                   new SelectionPrompt<string>()
                       .Title("Selecione [blue]sua armadura[/]")
                       .PageSize(10)
                       .MoreChoicesText("[grey]Mova para cima e para baixo para descobrir suas opções[/]")
                       .AddChoices(new[] {
                                "Uchigatana", "Adaga de ContrAtaque","Espada Larga","Rapieira","Voltar"
                           }));
                    Console.Clear();

                    var result = Console.ReadKey();
                    


                    switch (Re2)
                    {
                        case "Uchigatana":

                            AnsiConsole.Markup("Você escolheu a [purple]Uchigatana[/], A katana com dano cortante de 90 e peso 3kg....\n");
                            //Console.WriteLine("Você escolheu a Uchigatana, A katana com dano cortante de 90 e peso 3kg....tem certeza ?");

                            var nice = AnsiConsole.Confirm("Tem certeza?");
                            //Console.WriteLine("s------>n----->");
                            //answ = Console.ReadLine();
                            if (nice == true)
                            {
                                peso = 3;
                                dano = 90;
                                qual = "Uchigatana";

                            }
                            else
                            {
                                goto teste;
                            }

                            break;
                        case "Adaga de ContrAtaque":
                        novamente2:
                            AnsiConsole.Markup("Você escolheu a [purple]a Adaga de ContraAtaque[/], A Adaga com ataque rápido e de dano de 54 e peso 1kg....\n");
                            //Console.WriteLine("Você escolheu , A Adaga com ataque rápido e de dano de 54 e peso 1kg....tem certeza ?");

                            var nice2 = AnsiConsole.Confirm("Tem certeza?");
                            //Console.WriteLine("s------>n----->");
                            //answ = Console.ReadLine();
                            if (nice2 == true)
                            {
                                peso = 1;
                                dano = 54;
                                qual = "Adaga de ContraAtaque";


                            }
                            else
                            {
                                goto teste;
                            }
                            break;

                        case "Espada Larga":
                        novamente3:
                            AnsiConsole.Markup("Você escolheu a [purple]Espada larga[/], A espada pesada e lenta mas poderosa com ataque de dano de 220 e peso 10kg....\n");
                            //Console.WriteLine("Você escolheu a Espada larga, A espada pesada e lenta mas poderosa com ataque de dano de 220 e peso 10kg....tem certeza ?");

                            //Console.WriteLine("s------>n----->");
                            //answ = Console.ReadLine();
                            var nice3 = AnsiConsole.Confirm("Tem certeza?");
                            if (nice3==true)
                            {
                                peso = 10;
                                dano = 220;
                                qual = "Espada larga";

                            }
                            else 
                            {
                                goto teste;
                            }
                            
                            break;

                        case "Rapieira":
                        novamente4:
                            AnsiConsole.Markup("Você escolheu a [purple]Rapieira[/], A ágil espada  de esgrima com ataque perfurante de dano de 73 e peso 2kg....\n");
                            //Console.WriteLine("Você escolheu a Rapieira, A ágil espada  de esgrima com ataque perfurante de dano de 73 e peso 2kg....tem certeza ?");

                            //Console.WriteLine("s------>n----->");
                            //answ = Console.ReadLine();
                            var nice4 = AnsiConsole.Confirm("Tem certeza?");
                            if (nice4==true)
                            {
                                peso = 2;
                                dano = 73;
                                qual = @"Rapieira";


                            }
                            else 
                            {
                                goto teste;
                            }
                            
                            break;
                        case "Voltar":
                            return;

                        default:
                            Console.WriteLine("Inválido, aperte enter e tente novamente");
                            Console.ReadLine();
                            goto teste;

                    }


                    
                    sqlConnection.Open();
                    string insertQuerry = $"INSERT INTO Armas(dano, peso, qual)VALUES('{dano}','{peso}','{qual}')";
                    SqlCommand insertCommand = new SqlCommand(insertQuerry, sqlConnection);
                    insertCommand.ExecuteNonQuery();
                    Console.WriteLine("Arma selecionada.... Aperte Enter para retornar....");
                    sqlConnection.Close();
                    Console.ReadLine();
                }

                }
                    
                       
                    
            
            catch (Exception)
            {
                Console.WriteLine("Entrada Inválida, aperte enter para tentar novamente");
                Console.ReadLine();
                goto teste;
            }


            




        }
    }
}
