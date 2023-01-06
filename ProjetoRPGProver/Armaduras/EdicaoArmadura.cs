using Microsoft.Data.SqlClient;
using ProjetoRPGProver.Services;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoRPGProver.Armaduras
{
    public class EdicaoArmadura
    {
        public static void Editar()
        {
        restartEditArmad:
            string connectionString = @"Data Source=.;Initial Catalog=PersonagemDB;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            ListArmadura listArmad = new ListArmadura();
            listArmad.ListArmad();

            AnsiConsole.Markup("Digite [red] 0 [/]para retornar\n");
            AnsiConsole.Markup("Digite o [red]ID[/] sua armadura para editar:\n");
            foreach (var item in listArmad.ArmaduraList)
            {
                AnsiConsole.Markup($"ID: {item.ID} | Nome da armadura: {item.Qual}\n");
            }
            try
            {
                int armadPick = int.Parse(Console.ReadLine());
                if (armadPick == 0) { return; }
                var armad = listArmad.ArmaduraList.FirstOrDefault(x => x.ID == armadPick);
                if (armad != null)
                {
                restartArmad:
                    Console.Clear();

                    //Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine();
                    Console.WriteLine("Digite 0 para retornar a lista de armaduras.....");
                    Console.WriteLine();
                    //Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Nome: {armad.Qual} , Defesa: {armad.DanoAbs} , Peso: {armad.Peso}");

                    var Re2 = AnsiConsole.Prompt(
                                   new SelectionPrompt<string>()
                                       .Title("Qual item deseja editar?")
                                       .PageSize(10)
                                       .MoreChoicesText("[grey]Mova para cima e para baixo para descobrir suas opções[/]")
                                       .AddChoices(new[] {
                                        "Nome da arma", "Defesa","Peso","Voltar"
                                               }));
                    //Console.WriteLine();
                    //Console.WriteLine("Digite o Número do Item que deseja Editar:");
                    //Console.WriteLine("1-Nome da arma");
                    //Console.WriteLine("2-Defesa");
                    //Console.WriteLine("3-Peso");
                    //Console.WriteLine();
                    sqlConnection.Open();
                    //var funItem = Console.ReadKey();
                    switch (Re2)
                    {
                        case "Nome da arma":
                            Console.WriteLine("Digite o novo Nome da armadura: ");
                            string qual = armad.Qual;
                            qual = Console.ReadLine();
                            if (qual == "0") { return; }
                            if (string.IsNullOrWhiteSpace(qual))
                            {
                                Console.WriteLine("o Nome da armadura não pode estar em Branco....");
                                sqlConnection.Close();
                                Console.ReadLine();
                                goto restartArmad;
                            }
                            string updateQuerry1 = $"UPDATE Armaduras SET qual = '{qual}' WHERE id = {armad.ID}";
                            SqlCommand updateCommand1 = new SqlCommand(updateQuerry1, sqlConnection);
                            updateCommand1.ExecuteNonQuery();
                            Console.WriteLine("Nome atualizado... Aperte Enter para continuar.");
                            sqlConnection.Close();
                            Console.ReadLine();
                            goto restartEditArmad;

                        case "Defesa":
                            denovo2:
                            Console.WriteLine("Digite a nova defesa: ");
                            int defesa = armad.DanoAbs;
                            string defesaRead = Console.ReadLine();
                            if (defesaRead == "0") { return; }
                            if (string.IsNullOrWhiteSpace(defesaRead))
                            {
                                Console.WriteLine("O campo estava em Branco");
                                sqlConnection.Close();
                                Console.ReadLine();
                                goto restartArmad;
                            }
                            defesa = int.Parse(defesaRead);
                            if (defesa < 0)
                            {
                                AnsiConsole.Markup("[underline red]Inválido, apenas numeros positivos[/]\n");
                                goto denovo2;
                            }

                            string updateQuerry3 = $"UPDATE Armaduras SET danoAbs = {defesa} WHERE id = {armad.ID}";
                            SqlCommand updateCommand3 = new SqlCommand(updateQuerry3, sqlConnection);
                            updateCommand3.ExecuteNonQuery();
                            Console.WriteLine("Defesa atualizada... Aperte Enter para continuar.");
                            sqlConnection.Close();
                            Console.ReadLine();
                            goto restartEditArmad;

                        case "Peso":
                            denovo1:
                            Console.WriteLine("Digite o novo Peso: ");
                            int peso = armad.Peso;
                            string pesoRead = Console.ReadLine();
                            if (pesoRead == "0") { return; }
                            if (string.IsNullOrWhiteSpace(pesoRead))
                            {
                                Console.WriteLine("O campo estava em Branco");
                                sqlConnection.Close();
                                Console.ReadLine();
                                goto restartArmad;
                            }
                            peso = int.Parse(pesoRead);
                            if (peso < 0)
                            {
                                AnsiConsole.Markup("[underline red]Inválido, apenas numeros positivos[/]\n");
                                goto denovo1;
                            }
                            string updateQuerry4 = $"UPDATE Armaduras SET peso = {peso} WHERE id = {armad.ID}";
                            SqlCommand updateCommand4 = new SqlCommand(updateQuerry4, sqlConnection);
                            updateCommand4.ExecuteNonQuery();
                            Console.WriteLine("Peso atualizado... Aperte Enter para continuar.");
                            sqlConnection.Close();
                            Console.ReadLine();
                            goto restartEditArmad;



                        case "Voltar":
                            goto restartEditArmad;

                        default:
                            Console.WriteLine();
                            AnsiConsole.Markup("[underline red]inválido.... Aperte Enter e tente novamente.[/]\n");
                            sqlConnection.Close();
                            Console.ReadLine();
                            goto restartArmad;

                    }
                }
                else
                {
                    //Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("O ID digitado é invalido... Aperte Enter e tente novamente.");
                    //Console.ResetColor();
                    Console.ReadLine();
                    goto restartEditArmad;
                }
            }
            catch (Exception)
            {
                //Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("Digite apenas números. Aperte Enter e tente novamente.");
                // Console.ResetColor();
                Console.ReadLine();
                goto restartEditArmad;
            }

        }

    }
}

