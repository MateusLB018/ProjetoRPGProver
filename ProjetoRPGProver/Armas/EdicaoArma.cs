using Microsoft.Data.SqlClient;
using ProjetoRPGProver.Services;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoRPGProver.Armas
{
    public class EdicaoArma
    {
        public static void Editar()
        {
        restartEditArma:
            string connectionString = @"Data Source=.;Initial Catalog=PersonagemDB;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            ListArma listArma = new ListArma();
            listArma.ListArm();

            AnsiConsole.Markup("Digite [red] 0 [/]para retornar\n");
            AnsiConsole.Markup("Digite o [red]ID[/] sua arma para editar:\n");
            foreach (var item in listArma.ArmaList)
            {
                AnsiConsole.Markup($"ID: [red]{item.ID}[/] | Nome da arma: [red]{item.Qual}[/]\n");
            }
            try
            {
                int armaPick = int.Parse(Console.ReadLine());
                if (armaPick == 0) { return; }
                var arma = listArma.ArmaList.FirstOrDefault(x => x.ID == armaPick);
                if (arma != null)
                {
                restartArma:
                    Console.Clear();

                    //Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine();
                    Console.WriteLine("Digite 0 para retornar a lista de arma.....");
                    Console.WriteLine();
                    //Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Nome: {arma.Qual} , Dano: {arma.Dano} , Peso: {arma.Peso}");

                    var Re2 = AnsiConsole.Prompt(
                                    new SelectionPrompt<string>()
                                        .Title("Qual item deseja editar?")
                                        .PageSize(10)
                                        .MoreChoicesText("[grey]Mova para cima e para baixo para descobrir suas opções[/]")
                                        .AddChoices(new[] {
                                        "Nome da arma", "Dano","Peso","Voltar"
                                                }));
                    /*Console.WriteLine();
                    Console.WriteLine("Digite o Número do Item que deseja Editar:");
                    Console.WriteLine("1-Nome da arma");
                    Console.WriteLine("2-Dano");
                    Console.WriteLine("3-Peso");
                    Console.WriteLine();*/
                    sqlConnection.Open();
                    //var funItem = Console.ReadKey();
                    switch (Re2)
                    {
                        case "Nome da arma":
                            Console.WriteLine(" Digite o novo Nome da arma: ");
                            string qual = arma.Qual;
                            qual = Console.ReadLine();
                            if (qual == "0") { return; }
                            if (string.IsNullOrWhiteSpace(qual))
                            {
                                Console.WriteLine("o Nome da arma não pode estar em Branco....");
                                sqlConnection.Close();
                                Console.ReadLine();
                                goto restartArma;
                            }
                            string updateQuerry1 = $"UPDATE Armas SET qual = '{qual}' WHERE id = {arma.ID}";
                            SqlCommand updateCommand1 = new SqlCommand(updateQuerry1, sqlConnection);
                            updateCommand1.ExecuteNonQuery();
                            Console.WriteLine("Nome atualizado... Aperte Enter para continuar.");
                            sqlConnection.Close();
                            Console.ReadLine();
                            goto restartEditArma;

                        case "Dano":
                            denovo1:
                            Console.WriteLine(" Digite a novo dano: ");
                            int dano = arma.Dano;
                            string danoRead = Console.ReadLine();
                            if (danoRead == "0") { return; }
                            if (string.IsNullOrWhiteSpace(danoRead))
                            {
                                Console.WriteLine("O campo estava em Branco");
                                sqlConnection.Close();
                                Console.ReadLine();
                                goto restartArma;
                            }
                            dano = int.Parse(danoRead);
                            if (dano < 0)
                            {
                                AnsiConsole.Markup("[underline red] Apenas numeros positivos por favor...tente novamente[/]\n");
                                goto denovo1;
                            }

                            string updateQuerry3 = $"UPDATE Armas SET dano = '{dano}' WHERE id = {arma.ID}";
                            SqlCommand updateCommand3 = new SqlCommand(updateQuerry3, sqlConnection);
                            updateCommand3.ExecuteNonQuery();
                            Console.WriteLine("Dano atualizada... Aperte Enter para continuar.");
                            sqlConnection.Close();
                            Console.ReadLine();
                            goto restartEditArma;

                        case "Peso":
                            denovo2:
                            Console.WriteLine(" Digite o novo Peso: ");
                            int peso = arma.Peso;
                            string pesoRead = Console.ReadLine();
                            if (pesoRead == "0") { return; }
                            if (string.IsNullOrWhiteSpace(pesoRead))
                            {
                                Console.WriteLine("O campo estava em Branco");
                                sqlConnection.Close();
                                Console.ReadLine();
                                goto restartArma;
                            }
                            peso = int.Parse(pesoRead);
                            if (peso < 0)
                            {
                                AnsiConsole.Markup("[underline red]Apenas numeros positivos, tente novamente[/]\n");
                                goto denovo2;
                            }

                            string updateQuerry4 = $"UPDATE Armas SET peso = '{peso}' WHERE id = {arma.ID}";
                            SqlCommand updateCommand4 = new SqlCommand(updateQuerry4, sqlConnection);
                            updateCommand4.ExecuteNonQuery();
                            Console.WriteLine("Peso atualizado... Aperte Enter para continuar.");
                            sqlConnection.Close();
                            Console.ReadLine();
                            goto restartEditArma;



                        case "Voltar":
                            goto restartEditArma;

                        default:
                            Console.WriteLine();
                            Console.WriteLine("inválido.... Aperte Enter e tente novamente.");
                            sqlConnection.Close();
                            Console.ReadLine();
                            goto restartArma;

                    }
                }
                else
                {
                    //Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("O ID digitado é invalido... Aperte Enter e tente novamente.");
                    //Console.ResetColor();
                    Console.ReadLine();
                    goto restartEditArma;
                }
            }
            catch (Exception)
            {
                //Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("Digite apenas números. Aperte Enter e tente novamente.");
                // Console.ResetColor();
                Console.ReadLine();
                goto restartEditArma;
            }

        }
        //restartEditArma:
        //    string connectionString = @"Data Source=.;Initial Catalog=PersonagemDB;Integrated Security=True";
        //    SqlConnection sqlConnection = new SqlConnection(connectionString);
        //    ListArma listArma = new ListArma();
        //    listArma.ListArm();

        //    AnsiConsole.Markup("digite [red] 0 [/]para retornar\n");
        //    //Console.WriteLine("digite 0 para retornar");
        //    AnsiConsole.Markup("Digite o  [red] ID da sua arma [/]para edita-la\n");
        //    //Console.WriteLine("Digite o ID sua arma para editar:");
        //    foreach (var item in listArma.ArmaList)
        //    {
        //        AnsiConsole.Markup($"ID: [red]{item.ID}[/] | Nome da arma: [red]{item.Qual}[/]");
        //    }
        //    try
        //    {
        //        int armaPick = int.Parse(Console.ReadLine());
        //        if (armaPick == 0) { return; }
        //        var arma = listArma.ArmaList.FirstOrDefault(x => x.ID == armaPick);
        //        if (arma != null)
        //        {
        //        restartArma:
        //            Console.Clear();

        //            //Console.ForegroundColor = ConsoleColor.Cyan;
        //            Console.WriteLine();
        //            AnsiConsole.Markup("Digite 0 para retornar a lista de armas.....");
        //            Console.WriteLine();
        //            //Console.ForegroundColor = ConsoleColor.Yellow;
        //            Console.WriteLine($"Nome: {arma.Qual} , Defesa: {arma.Dano} , Peso: {arma.Peso}");


        //            var Re2 = AnsiConsole.Prompt(
        //                new SelectionPrompt<string>()
        //                    .Title("Qual item deseja editar?")
        //                    .PageSize(10)
        //                    .MoreChoicesText("[grey]Mova para cima e para baixo para descobrir suas opções[/]")
        //                    .AddChoices(new[] {
        //                    "Nome da arma", "Dano","Peso","Voltar"
        //                            }));
        //           /* Console.WriteLine();
        //            Console.WriteLine("Digite o Número do Item que deseja Editar:");
        //            Console.WriteLine("1-Nome da arma");
        //            Console.WriteLine("2-Dano");
        //            Console.WriteLine("3-Peso");
        //            Console.WriteLine();
        //            sqlConnection.Open();
        //            var funItem = Console.ReadKey();*/
        //            switch (Re2)
        //            {
        //                case "Nome da arma":
        //                    Console.WriteLine(" - Digite o novo Nome da arma: ");
        //                    string qual = arma.Qual;
        //                    qual = Console.ReadLine();
        //                    if (qual == "0") { return; }
        //                    if (string.IsNullOrWhiteSpace(qual))
        //                    {
        //                        Console.WriteLine("o Nome da arma não pode estar em Branco....");
        //                        sqlConnection.Close();
        //                        Console.ReadLine();
        //                        goto restartArma;
        //                    }
        //                    string updateQuerry1 = $"UPDATE Armas SET qual = '{qual}' WHERE id = {arma.ID}";
        //                    SqlCommand updateCommand1 = new SqlCommand(updateQuerry1, sqlConnection);
        //                    updateCommand1.ExecuteNonQuery();
        //                    Console.WriteLine("Nome atualizado... Aperte Enter para continuar.");
        //                    sqlConnection.Close();
        //                    Console.ReadLine();
        //                    goto restartEditArma;

        //                case "Dano":
        //                    Console.WriteLine(" - Digite o novo dano: ");
        //                    //int dano = arma.Dano;
        //                    string danoRead = Console.ReadLine();
        //                    if (danoRead == "0") { return; }
        //                    if (string.IsNullOrWhiteSpace(danoRead))
        //                    {
        //                        Console.WriteLine("O campo estava em Branco");
        //                        sqlConnection.Close();
        //                        Console.ReadLine();
        //                        goto restartArma;
        //                    }
        //                    arma.Dano = int.Parse(danoRead);

        //                    string updateQuerry3 = $"UPDATE Armas SET dano = '{arma.Dano}' WHERE id = {arma.ID}";
        //                    SqlCommand updateCommand3 = new SqlCommand(updateQuerry3, sqlConnection);
        //                    updateCommand3.ExecuteNonQuery();
        //                    Console.WriteLine("Dano atualizado... Aperte Enter para continuar.");
        //                    sqlConnection.Close();
        //                    Console.ReadLine();
        //                    goto restartEditArma;

        //                case "Peso":
        //                    Console.WriteLine(" - Digite o novo Peso: ");
        //                    int peso = arma.Peso;
        //                    string pesoRead = Console.ReadLine();
        //                    if (pesoRead == "0") { return; }
        //                    if (string.IsNullOrWhiteSpace(pesoRead))
        //                    {
        //                        Console.WriteLine("O campo estava em Branco");
        //                        sqlConnection.Close();
        //                        Console.ReadLine();
        //                        goto restartArma;
        //                    }
        //                    peso = int.Parse(pesoRead);

        //                    string updateQuerry4 = $"UPDATE Armas SET peso = '{peso}' WHERE id = {arma.ID}";
        //                    SqlCommand updateCommand4 = new SqlCommand(updateQuerry4, sqlConnection);
        //                    updateCommand4.ExecuteNonQuery();
        //                    AnsiConsole.Markup("[blue]Peso atualizado[/]... Aperte Enter para continuar.");
        //                    sqlConnection.Close();
        //                    Console.ReadLine();
        //                    goto restartEditArma;



        //                case "Voltar":
        //                    goto restartEditArma;

        //                default:
        //                    Console.WriteLine();
        //                    AnsiConsole.Markup("[underline red]inválido.... Aperte Enter e tente novamente.[/]");
        //                    sqlConnection.Close();
        //                    Console.ReadLine();
        //                    goto restartArma;

        //            }
        //        }
        //        else
        //        {
        //            //Console.ForegroundColor = ConsoleColor.Red;
        //            Console.WriteLine();
        //            AnsiConsole.Markup("[underline red]O ID digitado é invalido... Aperte Enter e tente novamente.[/]");
        //            //Console.ResetColor();
        //            Console.ReadLine();
        //            goto restartEditArma;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        //Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine();

        //        AnsiConsole.Markup("[underline red]Digite apenas números. Aperte Enter e tente novamente.[/]");

        //        // Console.ResetColor();
        //        Console.ReadLine();
        //        goto restartEditArma;
        //    }

        //}
    }
}
