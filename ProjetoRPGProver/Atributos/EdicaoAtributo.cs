using Microsoft.Data.SqlClient;
using ProjetoRPGProver.Services;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoRPGProver.Atributos
{
    public class EdicaoAtributo
    {
        public static void Editar()
        {
        restartEditAtribu:
            string connectionString = @"Data Source=.;Initial Catalog=PersonagemDB;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            ListAtributos listAtribut = new ListAtributos();
            listAtribut.ListAtribu();

            AnsiConsole.Markup("Digite [red] 0 [/]para retornar\n");
            AnsiConsole.Markup("Digite o [red]ID[/] sua classe para editar seus atributos:\n");
            foreach (var item in listAtribut.AtributoList)
            {
                AnsiConsole.Markup($"|[blue]ID[/] [red]{item.ID}[/] [blue]Inteligencia:[/] [red]{ item.Inteligencia}[/]| [blue]Força:[/] [red]{ item.Força}[/]| [blue]Fe:[/] [red]{ item.Fe}[/]| [blue]Vitalidade:[/] [red]{ item.Vitalidade}[/]| [blue]Energia:[/] [red]{ item.Energia}[/]| [blue]Magia:[/] [red]{ item.Magia}[/]| [blue]Vigor:[/] [red]{ item.Vigor}[/]| [blue]Defesa:[/] [red]{ item.Defesa}[/]\n");
                   
            }
            try
            {
                int atributoPick = int.Parse(Console.ReadLine());
                if (atributoPick == 0) { return; }
                var atribu = listAtribut.AtributoList.FirstOrDefault(x => x.ID == atributoPick);
                if (atribu != null)
                {
                restartAtributo:
                    Console.Clear();

                    //Console.ForegroundColor = ConsoleColor.Cyan;
                    //Console.WriteLine();
                    //Console.WriteLine("Digite 0 para retornar a lista de arma.....");
                    //Console.WriteLine();
                    ////Console.ForegroundColor = ConsoleColor.Yellow;
                    //Console.WriteLine($"Nome: {atribu.Qual} , Dano: {atribu.Dano} , Peso: {atribu.Peso}");

                    var Re2 = AnsiConsole.Prompt(
                                    new SelectionPrompt<string>()
                                        .Title("Qual item deseja editar?")
                                        .PageSize(10)
                                        .MoreChoicesText("[grey]Mova para cima e para baixo para descobrir suas opções[/]")
                                        .AddChoices(new[] {
                                        "Inteligencia", "Força","Fe","Vitalidade","Energia","Magia","Vigor","Defesa","Volar"
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
                        case "Inteligencia":
                            denovo1:
                            Console.WriteLine(" Digite a nova Inteligencia: ");
                            int inteli = atribu.Inteligencia;
                            string inteliRead = Console.ReadLine();
                            
                            if (inteliRead == "0") { return; }
                            if (string.IsNullOrWhiteSpace(inteliRead))
                            {
                                Console.WriteLine("não pode estar em Branco....");
                                sqlConnection.Close();
                                Console.ReadLine();
                                goto restartAtributo;
                            }
                            inteli = int.Parse(inteliRead);
                            if (inteli < 0)
                            {
                                AnsiConsole.Markup("[underline red] Apenas numeros positivos por favor...tente novamente[/]\n");
                                goto denovo1;
                            }
                            string updateQuerry1 = $"UPDATE Atributo SET inteligencia = '{inteli}' WHERE id = {atribu.ID}";
                            SqlCommand updateCommand1 = new SqlCommand(updateQuerry1, sqlConnection);
                            updateCommand1.ExecuteNonQuery();
                            Console.WriteLine("Inteligencia atualizada... Aperte Enter para continuar.");
                            sqlConnection.Close();
                            Console.ReadLine();
                            goto restartEditAtribu;

                        case "Força":
                        denovo2:
                            Console.WriteLine(" Digite a nova Força: ");
                            int forca = atribu.Força;
                            string forcaRead = Console.ReadLine();
                            if (forcaRead == "0") { return; }
                            if (string.IsNullOrWhiteSpace(forcaRead))
                            {
                                Console.WriteLine("O campo estava em Branco");
                                sqlConnection.Close();
                                Console.ReadLine();
                                goto restartAtributo;
                            }
                            forca = int.Parse(forcaRead);
                            if (forca < 0)
                            {
                                AnsiConsole.Markup("[underline red] Apenas numeros positivos por favor...tente novamente[/]\n");
                                goto denovo2;
                            }

                            string updateQuerry3 = $"UPDATE Atributo SET força = '{forca}' WHERE id = {atribu.ID}";
                            SqlCommand updateCommand3 = new SqlCommand(updateQuerry3, sqlConnection);
                            updateCommand3.ExecuteNonQuery();
                            Console.WriteLine("Força atualizada... Aperte Enter para continuar.");
                            sqlConnection.Close();
                            Console.ReadLine();
                            goto restartEditAtribu;

                        case "Fe":
                        denovo3:
                            Console.WriteLine(" Digite a nova Fé: ");
                            int fe= atribu.Fe;
                            string feRead = Console.ReadLine();
                            if (feRead == "0") { return; }
                            if (string.IsNullOrWhiteSpace(feRead))
                            {
                                Console.WriteLine("O campo estava em Branco");
                                sqlConnection.Close();
                                Console.ReadLine();
                                goto restartAtributo;
                            }
                            fe = int.Parse(feRead);
                            if (fe < 0)
                            {
                                AnsiConsole.Markup("[underline red]Apenas numeros positivos, tente novamente[/]\n");
                                goto denovo3;
                            }

                            string updateQuerry4 = $"UPDATE Atributo SET fe = '{fe}' WHERE id = {atribu.ID}";
                            SqlCommand updateCommand4 = new SqlCommand(updateQuerry4, sqlConnection);
                            updateCommand4.ExecuteNonQuery();
                            Console.WriteLine("Fe atualizado... Aperte Enter para continuar.");
                            sqlConnection.Close();
                            Console.ReadLine();
                            goto restartEditAtribu;
                        case "Vitalidade":
                        denovo4:
                            Console.WriteLine(" Digite a nova Vitalidade: ");
                            int vit = atribu.Vitalidade;
                            string vitoRead = Console.ReadLine();
                            if (vitoRead == "0") { return; }
                            if (string.IsNullOrWhiteSpace(vitoRead))
                            {
                                Console.WriteLine("O campo estava em Branco");
                                sqlConnection.Close();
                                Console.ReadLine();
                                goto restartAtributo;
                            }
                            vit = int.Parse(vitoRead);
                            if (vit < 0)
                            {
                                AnsiConsole.Markup("[underline red]Apenas numeros positivos, tente novamente[/]\n");
                                goto denovo4;
                            }

                            string updateQuerry5 = $"UPDATE Atributo SET vitalidade = '{vit}' WHERE id = {atribu.ID}";
                            SqlCommand updateCommand5 = new SqlCommand(updateQuerry5, sqlConnection);
                            updateCommand5.ExecuteNonQuery();
                            Console.WriteLine("Vitalidade atualizada... Aperte Enter para continuar.");
                            sqlConnection.Close();
                            Console.ReadLine();
                            goto restartEditAtribu;
                            //Energia
                        case "Energia":
                        denovo5:
                            Console.WriteLine("Digite a nova Energia: ");
                            int energ = atribu.Energia;
                            string energRead = Console.ReadLine();
                            if (energRead == "0") { return; }
                            if (string.IsNullOrWhiteSpace(energRead))
                            {
                                Console.WriteLine("O campo estava em Branco");
                                sqlConnection.Close();
                                Console.ReadLine();
                                goto restartAtributo;
                            }
                            energ = int.Parse(energRead);
                            if (energ < 0)
                            {
                                AnsiConsole.Markup("[underline red]Apenas numeros positivos, tente novamente[/]\n");
                                goto denovo5; //Magia
                            }
                            string updateQuerry6 = $"UPDATE Atributo SET energia = '{energ}' WHERE id = {atribu.ID}";
                            SqlCommand updateCommand6 = new SqlCommand(updateQuerry6, sqlConnection);
                            updateCommand6.ExecuteNonQuery();
                            Console.WriteLine("Energia atualizada... Aperte Enter para continuar.");
                            sqlConnection.Close();
                            Console.ReadLine();
                            goto restartEditAtribu;

                        case "Magia":
                        denovo6:
                            Console.WriteLine("Digite a nova Magia: ");
                            int mag = atribu.Magia;
                            string magRead = Console.ReadLine();
                            if (magRead == "0") { return; }
                            if (string.IsNullOrWhiteSpace(magRead))
                            {
                                Console.WriteLine("O campo estava em Branco");
                                sqlConnection.Close();
                                Console.ReadLine();
                                goto restartAtributo;
                            }
                            mag = int.Parse(magRead);
                            if (mag < 0)
                            {
                                AnsiConsole.Markup("[underline red]Apenas numeros positivos, tente novamente[/]\n");
                                goto denovo6;//
                            }

                            string updateQuerry7 = $"UPDATE Atributo SET magia = '{mag}' WHERE id = {atribu.ID}";
                            SqlCommand updateCommand7 = new SqlCommand(updateQuerry7, sqlConnection);
                            updateCommand7.ExecuteNonQuery();
                            Console.WriteLine("Magia atualizado... Aperte Enter para continuar.");
                            sqlConnection.Close();
                            Console.ReadLine();
                            goto restartEditAtribu;
                        case "Vigor":
                        denovo7:
                            Console.WriteLine("Digite o novo Vigor: ");
                            int vig = atribu.Vigor;
                            string vigRead = Console.ReadLine();
                            if (vigRead == "0") { return; }
                            if (string.IsNullOrWhiteSpace(vigRead))
                            {
                                Console.WriteLine("O campo estava em Branco");
                                sqlConnection.Close();
                                Console.ReadLine();
                                goto restartAtributo;
                            }
                            vig = int.Parse(vigRead);
                            if (vig < 0)
                            {
                                AnsiConsole.Markup("[underline red]Apenas numeros positivos, tente novamente[/]\n");
                                goto denovo7;
                            }

                            string updateQuerry8 = $"UPDATE Atributo SET vigor = '{vig}' WHERE id = {atribu.ID}";
                            SqlCommand updateCommand8 = new SqlCommand(updateQuerry8, sqlConnection);
                            updateCommand8.ExecuteNonQuery();
                            Console.WriteLine("Vigor atualizado... Aperte Enter para continuar.");
                            sqlConnection.Close();
                            Console.ReadLine();
                            goto restartEditAtribu;
                        case "Defesa":
                        denovo8:
                            Console.WriteLine("Digite a nova Defesa: ");
                            int defe = atribu.Defesa;
                            string defeRead = Console.ReadLine();
                            if (defeRead == "0") { return; }
                            if (string.IsNullOrWhiteSpace(defeRead))
                            {
                                Console.WriteLine("O campo estava em Branco");
                                sqlConnection.Close();
                                Console.ReadLine();
                                goto restartAtributo;
                            }
                            defe = int.Parse(defeRead);
                            if (defe < 0)
                            {
                                AnsiConsole.Markup("[underline red]Apenas numeros positivos, tente novamente[/]\n");
                                goto denovo8;
                            }

                            string updateQuerry9 = $"UPDATE Atributo SET defesa = '{defe}' WHERE id = {atribu.ID}";
                            SqlCommand updateCommand9 = new SqlCommand(updateQuerry9, sqlConnection);
                            updateCommand9.ExecuteNonQuery();
                            Console.WriteLine("Defesa atualizada... Aperte Enter para continuar.");
                            sqlConnection.Close();
                            Console.ReadLine();
                            goto restartEditAtribu;


                        case "Voltar":
                            goto restartEditAtribu;

                        default:
                            Console.WriteLine();
                            Console.WriteLine("inválido.... Aperte Enter e tente novamente.");
                            sqlConnection.Close();
                            Console.ReadLine();
                            goto restartAtributo;

                    }
                }
                else
                {
                    //Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("O ID digitado é invalido... Aperte Enter e tente novamente.");
                    //Console.ResetColor();
                    Console.ReadLine();
                    goto restartEditAtribu;
                }
            }
            catch (Exception)
            {
                //Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("Digite apenas números. Aperte Enter e tente novamente.");
                // Console.ResetColor();
                Console.ReadLine();
                goto restartEditAtribu;
            }

        }
        //restartEditArmad:
        //    string connectionString = @"Data Source=.;Initial Catalog=PersonagemDB;Integrated Security=True";
        //    SqlConnection sqlConnection = new SqlConnection(connectionString);
        //    ListAtributos listAtri = new ListAtributos();
        //    listAtri.ListAtribu();
        //    //inteligencia: " + inteligencia + "\nforça: " + forca + "\nfe: " + fe + "\nvitalidade: " + vitalidade + "\nenergia: " + energia + "\nmagia: " + magia + "\ndefesa: " + defesa + "\nvigor: " + vigor
        //    AnsiConsole.Markup("digite [underline red] 0 [/]para retornar\n");
        //    Console.WriteLine("Digite o ID seus atributos para editar:");
        //    foreach (var item in listAtri.AtributoList)
        //    {
        //        Console.WriteLine($"ID: {item.ID} | Inteligencia: {item.Inteligencia}| Força: {item.Força}| Fe: {item.Fe}| Vitalidade: {item.Vitalidade}| Energia: {item.Energia}| Magia: {item.Magia}| Vigor: {item.Vigor}| Defesa: {item.Defesa}");
        //    }
        //    //try
        //    //{
        //        int atriPick = int.Parse(Console.ReadLine());
        //        if (atriPick == 0) { return; }
        //        var aitem = listAtri.AtributoList.FirstOrDefault(x => x.ID == atriPick);
        //        if (aitem != null)
        //        {
        //        restartArmad:
        //            Console.Clear();

        //            //Console.ForegroundColor = ConsoleColor.Cyan;
        //            Console.WriteLine();
        //            Console.WriteLine("Digite 0 para retornar a lista de atributos.....");
        //            Console.WriteLine();
        //            //Console.ForegroundColor = ConsoleColor.Yellow;

        //            Console.WriteLine($" Inteligencia: {aitem.Inteligencia}| Força: {aitem.Força}| Fe: {aitem.Fe}| Vitalidade: {aitem.Vitalidade}| Energia: {aitem.Energia}| Magia: {aitem.Magia}| Vigor: {aitem.Vigor}| Defesa: {aitem.Defesa}");




        //            Console.WriteLine();
        //            Console.WriteLine("Digite o Número do Item que deseja Editar:");
        //            Console.WriteLine("1-Inteligencia");
        //            Console.WriteLine("2-Força");
        //            Console.WriteLine("3-Fe");
        //            Console.WriteLine("4-vitalidade");
        //            Console.WriteLine("5-Energia");
        //            Console.WriteLine("6-Magia");
        //            Console.WriteLine("7-Vigor");
        //            Console.WriteLine("8-Defesa");
        //            Console.WriteLine();
        //            sqlConnection.Open();
        //            var funItem = Console.ReadKey();
        //            switch (funItem.KeyChar)
        //            {
        //                case '1':
        //                    Console.WriteLine(" - Digite a nova inteligencia: ");
        //                    int defesa = aitem.Inteligencia;
        //                    string defesaRead = Console.ReadLine();
        //                    if (defesaRead == "0") { return; }
        //                    if (string.IsNullOrWhiteSpace(defesaRead))
        //                    {
        //                        Console.WriteLine("O campo estava em Branco");
        //                        sqlConnection.Close();
        //                        Console.ReadLine();
        //                        goto restartArmad;
        //                    }
        //                    defesa = int.Parse(defesaRead);

        //                    string updateQuerry1 = $"UPDATE Atributos SET inteligencia = '{defesa}' WHERE id = {aitem.ID}";
        //                    SqlCommand updateCommand1 = new SqlCommand(updateQuerry1, sqlConnection);
        //                    updateCommand1.ExecuteNonQuery();
        //                    Console.WriteLine("Inteligencia atualizada... Aperte Enter para continuar.");
        //                    sqlConnection.Close();
        //                    Console.ReadLine();
        //                    goto restartEditArmad;

        //                case '2':
        //                    Console.WriteLine(" - Digite a nova força: ");
        //                    int forca = aitem.Força;
        //                    string forcaRead = Console.ReadLine();
        //                    if (forcaRead == "0") { return; }
        //                    if (string.IsNullOrWhiteSpace(forcaRead))
        //                    {
        //                        Console.WriteLine("O campo estava em Branco");
        //                        sqlConnection.Close();
        //                        Console.ReadLine();
        //                        goto restartArmad;
        //                    }
        //                    defesa = int.Parse(forcaRead);

        //                    string updateQuerry2 = $"UPDATE Atributos SET força= '{forca}' WHERE id = {aitem.ID}";
        //                    SqlCommand updateCommand2 = new SqlCommand(updateQuerry2, sqlConnection);
        //                    updateCommand2.ExecuteNonQuery();
        //                    Console.WriteLine("Força atualizada... Aperte Enter para continuar.");
        //                    sqlConnection.Close();
        //                    Console.ReadLine();
        //                    goto restartEditArmad;

        //                case '3':
        //                    Console.WriteLine(" - Digite a nova fe: ");
        //                    int fe = aitem.Fe;
        //                    string feRead = Console.ReadLine();
        //                    if (feRead == "0") { return; }
        //                    if (string.IsNullOrWhiteSpace(feRead))
        //                    {
        //                        Console.WriteLine("O campo estava em Branco");
        //                        sqlConnection.Close();
        //                        Console.ReadLine();
        //                        goto restartArmad;
        //                    }
        //                    defesa = int.Parse(feRead);

        //                    string updateQuerry3 = $"UPDATE Atributos SET fe = '{fe}' WHERE id = {aitem.ID}";
        //                    SqlCommand updateCommand3 = new SqlCommand(updateQuerry3, sqlConnection);
        //                    updateCommand3.ExecuteNonQuery();
        //                    Console.WriteLine("Fe atualizada... Aperte Enter para continuar.");
        //                    sqlConnection.Close();
        //                    Console.ReadLine();
        //                    goto restartEditArmad;
        //                case '4':
        //                    Console.WriteLine(" - Digite a nova vitalidade: ");
        //                    int vitalidade = aitem.Vitalidade;
        //                    string vitaRead = Console.ReadLine();
        //                    if (vitaRead == "0") { return; }
        //                    if (string.IsNullOrWhiteSpace(vitaRead))
        //                    {
        //                        Console.WriteLine("O campo estava em Branco");
        //                        sqlConnection.Close();
        //                        Console.ReadLine();
        //                        goto restartArmad;
        //                    }
        //                    defesa = int.Parse(vitaRead);

        //                    string updateQuerry4 = $"UPDATE Atributos SET vitalidade = '{vitalidade}' WHERE id = {aitem.ID}";
        //                    SqlCommand updateCommand4 = new SqlCommand(updateQuerry4, sqlConnection);
        //                    updateCommand4.ExecuteNonQuery();
        //                    Console.WriteLine("Vitalidade atualizada... Aperte Enter para continuar.");
        //                    sqlConnection.Close();
        //                    Console.ReadLine();
        //                    goto restartEditArmad;
        //                case '5':
        //                    Console.WriteLine(" - Digite a nova Energia: ");
        //                    int energia = aitem.Energia;
        //                    string energiaRead = Console.ReadLine();
        //                    if (energiaRead == "0") { return; }
        //                    if (string.IsNullOrWhiteSpace(energiaRead))
        //                    {
        //                        Console.WriteLine("O campo estava em Branco");
        //                        sqlConnection.Close();
        //                        Console.ReadLine();
        //                        goto restartArmad;
        //                    }
        //                    defesa = int.Parse(energiaRead);

        //                    string updateQuerry5 = $"UPDATE Atributos SET energia = '{energia}' WHERE id = {aitem.ID}";
        //                    SqlCommand updateCommand5 = new SqlCommand(updateQuerry5, sqlConnection);
        //                    updateCommand5.ExecuteNonQuery();
        //                    Console.WriteLine("Energia atualizada... Aperte Enter para continuar.");
        //                    sqlConnection.Close();
        //                    Console.ReadLine();
        //                    goto restartEditArmad;
        //                case '6':
        //                    Console.WriteLine(" - Digite a nova Magia: ");
        //                    int magia = aitem.Magia;
        //                    string magiaRead = Console.ReadLine();
        //                    if (magiaRead == "0") { return; }
        //                    if (string.IsNullOrWhiteSpace(magiaRead))
        //                    {
        //                        Console.WriteLine("O campo estava em Branco");
        //                        sqlConnection.Close();
        //                        Console.ReadLine();
        //                        goto restartArmad;
        //                    }
        //                    defesa = int.Parse(magiaRead);

        //                    string updateQuerry6 = $"UPDATE Atributos SET magia = '{magia}' WHERE id = {aitem.ID}";
        //                    SqlCommand updateCommand6 = new SqlCommand(updateQuerry6, sqlConnection);
        //                    updateCommand6.ExecuteNonQuery();
        //                    Console.WriteLine("Maagia atualizada... Aperte Enter para continuar.");
        //                    sqlConnection.Close();
        //                    Console.ReadLine();
        //                    goto restartEditArmad;
        //                case '7':
        //                    Console.WriteLine(" - Digite a nova Vigor: ");
        //                    int vigor = aitem.Vigor;
        //                    string vigorRead = Console.ReadLine();
        //                    if (vigorRead == "0") { return; }
        //                    if (string.IsNullOrWhiteSpace(vigorRead))
        //                    {
        //                        Console.WriteLine("O campo estava em Branco");
        //                        sqlConnection.Close();
        //                        Console.ReadLine();
        //                        goto restartArmad;
        //                    }
        //                    defesa = int.Parse(vigorRead);

        //                    string updateQuerry7 = $"UPDATE Atributos SET vigor = '{vigor}' WHERE id = {aitem.ID}";
        //                    SqlCommand updateCommand7 = new SqlCommand(updateQuerry7, sqlConnection);
        //                    updateCommand7.ExecuteNonQuery();
        //                    Console.WriteLine("Vigor atualizado... Aperte Enter para continuar.");
        //                    sqlConnection.Close();
        //                    Console.ReadLine();
        //                    goto restartEditArmad;
        //                case '8':
        //                    Console.WriteLine(" - Digite a nova Defesa: ");
        //                    int defesa1 = aitem.Magia;
        //                    string defesa1Read = Console.ReadLine();
        //                    if (defesa1Read == "0") { return; }
        //                    if (string.IsNullOrWhiteSpace(defesa1Read))
        //                    {
        //                        Console.WriteLine("O campo estava em Branco");
        //                        sqlConnection.Close();
        //                        Console.ReadLine();
        //                        goto restartArmad;
        //                    }
        //                    defesa = int.Parse(defesa1Read);

        //                    string updateQuerry8 = $"UPDATE Atributos SET defesa = '{defesa1}' WHERE id = {aitem.ID}";
        //                    SqlCommand updateCommand8 = new SqlCommand(updateQuerry8, sqlConnection);
        //                    updateCommand8.ExecuteNonQuery();
        //                    Console.WriteLine("Defesa atualizada... Aperte Enter para continuar.");
        //                    sqlConnection.Close();
        //                    Console.ReadLine();
        //                    goto restartEditArmad;



        //                case '0':
        //                    goto restartArmad;

        //                default:
        //                    Console.WriteLine();
        //                    Console.WriteLine("inválido.... Aperte Enter e tente novamente.");
        //                    sqlConnection.Close();
        //                    Console.ReadLine();
        //                    goto restartArmad;

        //            }
        //        }
        //        else
        //        {
        //            //Console.ForegroundColor = ConsoleColor.Red;
        //            Console.WriteLine();
        //            Console.WriteLine("O ID digitado é invalido... Aperte Enter e tente novamente.");
        //            //Console.ResetColor();
        //            Console.ReadLine();
        //            goto restartEditArmad;
        //        }

        /*catch (Exception)
        {
            //Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("Digite apenas números. Aperte Enter e tente novamente.");
            // Console.ResetColor();
            Console.ReadLine();
            goto restartEditArmad;
        }*/

    }
    }
    

