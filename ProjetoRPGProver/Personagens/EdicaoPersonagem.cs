using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Data.SqlClient;
using ProjetoRPGProver.Services;
using Spectre.Console;

namespace ProjetoRPGProver.Personagens
{
    public class Personagen
    {
        public static void Editar()
        {
        restartEditArmad:
            string connectionString = @"Data Source=.;Initial Catalog=PersonagemDB;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            ListPersonagem listPer = new ListPersonagem();
            listPer.ListPerso();

            AnsiConsole.Markup("digite [underline red] 0 [/]para retornar\n");
            AnsiConsole.Markup("Digite [red]ID[/] seu personagem para editar:\n");
            foreach (var item in listPer.PersonagemList)
            {
                AnsiConsole.Markup($"[blue]ID:[/] [red]{item.ID}[/] | [blue]Nome do personagem:[/] [red]{item.Nome}[/]");
            }
            try
            {
                int perPick = int.Parse(Console.ReadLine());
                if (perPick == 0) { return; }
                var persd = listPer.PersonagemList.FirstOrDefault(x => x.ID == perPick);
                if (persd != null)
                {
                restartArmad:
                    Console.Clear();

                    //Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine();
                    Console.WriteLine("Digite 0 para retornar a lista de armas.....");
                    Console.WriteLine();
                    //Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Nome: {persd.Nome} , Idade: {persd.Idade} , Peso: {persd.Peso}, Sexo: {persd.Sexo}, Item Inicial: {persd.ItemIni}");
                    //Peso: { personagem.Peso}| Idade: { personagem.Idade}| Sexo: { personagem.Sexo}| Item inicial

                    //Console.WriteLine();
                    //Console.WriteLine("Digite o Número do Item que deseja Editar:");
                    //Console.WriteLine("1-Nome do personagem");
                    //Console.WriteLine("2-Idade");
                    //Console.WriteLine("3-Peso");
                    //Console.WriteLine("4-Sexo");
                    //Console.WriteLine("5-Item Inicial");
                    //Console.WriteLine();
                    var Re2 = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("O que fazer quanto aos [blue]seus atributos[/]")
                            .PageSize(10)
                            .MoreChoicesText("[grey]Mova para cima e para baixo para descobrir suas opções[/]")
                            .AddChoices(new[] {
                            "Nome", "Idade","Peso", "Sexo","Item Inicial","Voltar"
                                    }));
                    sqlConnection.Open();
                    //var funItem = Console.ReadKey();
                    switch (Re2)
                    {
                        case "Nome":
                            Console.WriteLine("Digite o novo Nome do personagem: ");
                            string nome = persd.Nome;
                            nome = Console.ReadLine();
                            if (nome == "0") { return; }
                            if (string.IsNullOrWhiteSpace(nome))
                            {
                                Console.WriteLine("o Nome não pode estar em Branco....");
                                sqlConnection.Close();
                                Console.ReadLine();
                                goto restartArmad;
                            }
                            string updateQuerry1 = $"UPDATE Personagem SET nome = '{nome}' WHERE id = {persd.ID}";
                            SqlCommand updateCommand1 = new SqlCommand(updateQuerry1, sqlConnection);
                            updateCommand1.ExecuteNonQuery();
                            Console.WriteLine("Nome atualizado... Aperte Enter para continuar.");
                            sqlConnection.Close();
                            Console.ReadLine();
                            goto restartEditArmad;

                        case "Idade":
                            Console.WriteLine("Digite a nova idade: ");
                            int defesa = persd.Idade;
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

                            string updateQuerry3 = $"UPDATE Personagem SET idade = '{defesa}' WHERE id = {persd.ID}";
                            SqlCommand updateCommand3 = new SqlCommand(updateQuerry3, sqlConnection);
                            updateCommand3.ExecuteNonQuery();
                            Console.WriteLine("Idade atualizada... Aperte Enter para continuar.");
                            sqlConnection.Close();
                            Console.ReadLine();
                            goto restartEditArmad;

                        case "Peso":
                            Console.WriteLine("Digite o novo Peso: ");
                            int peso = persd.Peso;
                            string pesoRead = Console.ReadLine();
                            if (pesoRead == "0") { return; }
                            if (string.IsNullOrWhiteSpace(pesoRead))
                            {
                                Console.WriteLine("O campo estava em Branco");
                                sqlConnection.Close();
                                Console.ReadLine();
                                goto restartArmad;
                            }
                            defesa = int.Parse(pesoRead);

                            string updateQuerry4 = $"UPDATE Personagem SET peso = '{defesa}' WHERE id = {persd.ID}";
                            SqlCommand updateCommand4 = new SqlCommand(updateQuerry4, sqlConnection);
                            updateCommand4.ExecuteNonQuery();
                            Console.WriteLine("Peso atualizado... Aperte Enter para continuar.");
                            sqlConnection.Close();
                            Console.ReadLine();
                            goto restartEditArmad;
                        case "Sexo":
                            Console.WriteLine("Digite o novo sexo do personagem: ");
                            string sexo = persd.Sexo;
                            sexo = Console.ReadLine();
                            if (sexo == "0") { return; }
                            if (string.IsNullOrWhiteSpace(sexo))
                            {
                                Console.WriteLine("não pode estar em Branco....");
                                sqlConnection.Close();
                                Console.ReadLine();
                                goto restartArmad;
                            }
                            string updateQuerry2 = $"UPDATE Personagem SET sexo = '{sexo}' WHERE id = {persd.ID}";
                            SqlCommand updateCommand2 = new SqlCommand(updateQuerry2, sqlConnection);
                            updateCommand2.ExecuteNonQuery();
                            Console.WriteLine("Sexo atualizado... Aperte Enter para continuar.");
                            sqlConnection.Close();
                            Console.ReadLine();
                            goto restartEditArmad;
                        case "Item Inicial":
                            Console.WriteLine("Digite o novo item inicial do personagem: ");
                            string itemI = persd.Sexo;
                            itemI = Console.ReadLine();
                            if (itemI == "0") { return; }
                            if (string.IsNullOrWhiteSpace(itemI))
                            {
                                Console.WriteLine("não pode estar em Branco....");
                                sqlConnection.Close();
                                Console.ReadLine();
                                goto restartArmad;
                            }
                            string updateQuerry5 = $"UPDATE Personagem SET itemIni = '{itemI}' WHERE id = {persd.ID}";
                            SqlCommand updateCommand5 = new SqlCommand(updateQuerry5, sqlConnection);
                            updateCommand5.ExecuteNonQuery();
                            Console.WriteLine("Item Inicial atualizado... Aperte Enter para continuar.");
                            sqlConnection.Close();
                            Console.ReadLine();
                            goto restartEditArmad;



                        case "Voltar":
                            goto restartEditArmad;

                        default:
                            Console.WriteLine();
                            AnsiConsole.Markup("[underline red]nválido.... Aperte Enter e tente novamente.[/]\n");
                            sqlConnection.Close();
                            Console.ReadLine();
                            goto restartArmad;

                    }
                }
                else
                {
                    //Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    AnsiConsole.Markup("[underline red]O ID digitado é invalido... Aperte Enter e tente novamente.[/]\n");
                    //Console.ResetColor();
                    Console.ReadLine();
                    goto restartEditArmad;
                }
            }
            catch (Exception)
            {
                //Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                AnsiConsole.Markup("[underline red]Digite apenas números. Aperte Enter e tente novamente.[/]\n");
                // Console.ResetColor();
                Console.ReadLine();
                goto restartEditArmad;
            }

        }
    }
}