/*using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ProjetoRPGProver.Contexto;
using ProjetoRPGProver.Models;
using ProjetoRPGProver.Services;
using Spectre.Console;

namespace ProjetoRPGProver.Personagens
{
    public class Personagens

    {
        public static void Criando()
        {

            string connectionString = @"Data Source=.;Initial Catalog=PersonagemDB;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            ListArma listArmas = new ListArma();
            listArmas.ListArm();

            ListArmadura listArmaduras = new ListArmadura();
            listArmaduras.ListArmad();

            ListAtributos listAtributos = new ListAtributos();
            listAtributos.ListAtribu();

            ListPoder listPoder = new ListPoder();
            listPoder.ListPod();

        voltar:
            try
            {
                Console.Clear();
                AnsiConsole.Markup("Qual é o seu [blue]nome:[/]\n");
                //Console.WriteLine("Qual é o seu nome: ");
                string nome = Console.ReadLine();

            novamente11:
                AnsiConsole.Markup("Qual é a sua [blue]idade:[/]\n");
                //Console.WriteLine("Qual é a sua idade: ");
                int idade = Convert.ToInt32(Console.ReadLine());

                if (idade < 0)
                {
                    Console.WriteLine("Inválido, digite novamente...");
                    goto novamente11;
                }

            novamente10:
                AnsiConsole.Markup("Qual é o seu [blue]peso:[/]\n");
                //Console.WriteLine("Qual é o seu peso: ");
                int peso = Convert.ToInt32(Console.ReadLine());
                if (peso < 0)
                {
                    Console.WriteLine("Inválido, digite novamente...");
                    goto novamente10;
                }



            novamente0:
                AnsiConsole.Markup("Qual é o seu [blue]sexo[/]M/F\n");
                //Console.WriteLine("Qual é o seu sexo: M/F ");
                string sexo = Console.ReadLine();
                if (sexo != "M" && sexo != "m" && sexo != "F" && sexo != "f")
                {
                    Console.WriteLine("Inválido, digite novamente...");
                    goto novamente0;
                }

            teste:
                Console.Clear();
                var Re2 = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Escolha seu [blue]item inicial[/] ")
                        .PageSize(10)
                        .MoreChoicesText("[grey]Mova para cima e para baixo para descobrir suas opções[/]")
                        .AddChoices(new[] {
                            "Anel da Vida", "Bomba Negra","Osso do Regresso", "Coroa de Escamas","Medalhão de prata","Criar"
                                }));
                //Console.WriteLine(" Escolha seu item inicial : ");
                //Console.WriteLine(" 1-Anel da Vida\n 2-Bomba Negra\n 3-Osso do Regresso\n 4-Coroa de Escamas\n 5-Medalhão de prata\n");
                //var result = Console.ReadKey();
                //string answ = "";
                string itemIni = "";
                string asw;
                switch (Re2)
                {
                    case "Anel da Vida":
                    novamente:
                        AnsiConsole.Markup("Então você escolheu [blue]anel da vida[/] o extensor de sua vitalidade...\n");
                        //Console.WriteLine("Então você escolha o anel da vida, o extensor de sua vitalidade....tem certeza ? ");
                        //Console.WriteLine("--------->s///////////---------->n");
                        //asw = Console.ReadLine();
                        var nice = AnsiConsole.Confirm("Tem Certeza ?");
                        if (nice == true)
                        {
                            itemIni = "Anel da Vida";
                        }
                        else
                        {
                            goto teste;
                        }
                        break;
                    case "Bomba Negra":
                    novamente2:
                        AnsiConsole.Markup("Então você escolheu a [blue]Bomba Negra[/] o mais poderoso explosivo....\n");
                        //Console.WriteLine(" Então você escolhe a Bomba negra, o mais poderoso explosivo... tem certeza ? ");
                        //Console.WriteLine("--------->s///////////---------->n");
                        asw = Console.ReadLine();
                        var nice2 = AnsiConsole.Confirm("Tem Certeza ?");
                        if (nice2 == true)
                        {
                            itemIni = "Bomba Negra";
                        }
                        else
                        {
                            goto teste;
                        }
                        break;
                    case "Osso do Regresso":
                    novamente3:
                        AnsiConsole.Markup("Então você escolheu o [blue]Osso do regresso[/] o item de retornar a qualquer lugar já passado....\n");
                        //Console.WriteLine(" Então você escolhe o Osso do regresso,o item de retornar a qualquer lugar já passado.... tem certeza ? ");
                        //Console.WriteLine("--------->s///////////---------->n");
                        //asw = Console.ReadLine();
                        var nice3 = AnsiConsole.Confirm("Tem Certeza ?");
                        if (nice3 == true)
                        {
                            itemIni = "Osso do regresso";
                        }
                        else
                        {
                            goto teste;
                        }
                        break;
                    case "Coroa de Escamas":
                    novamente4:
                        AnsiConsole.Markup("Então você escolheu a [blue]coroa de escamas[/] o estranho item de camuflagem....\n");
                        //Console.WriteLine(" Então você escolhe a coroa de escamas,o estranho item de camuflagem.... tem certeza ? ");
                        //Console.WriteLine("--------->s///////////---------->n");
                        //asw = Console.ReadLine();
                        var nice4 = AnsiConsole.Confirm("Tem Certeza ?");
                        if (nice4 == true)
                        {
                            itemIni = "coroa de escamas";
                        }
                        else
                        {
                            goto teste;
                        }
                        break;
                    case "Medalhão de prata":
                    novamente5:
                        //Console.WriteLine(" Então você escolhe o Medalhão de prata,o misterioso item de poder desconhecido.... tem certeza ? ");
                        //Console.WriteLine("--------->s///////////---------->n");
                        AnsiConsole.Markup("Então você escolheu o [blue]Medalhão de prata[/] o misterioso item de poder desconhecido....\n");
                        //asw = Console.ReadLine();
                        var nice5 = AnsiConsole.Confirm("Tem Certeza ?");
                        if (nice5)
                        {
                            itemIni = "Medalhão de prata";
                        }
                        else
                        {
                            goto teste;
                        }
                        break;
                    case "Criar":
                        AnsiConsole.Markup("Então você escolheu [blue]Criar[/] o seu item....\n");
                        AnsiConsole.Markup("Digite o seu [blue]item inicial[/].....\n");
                        itemIni = Console.ReadLine();
                        break;
                    default:
                        break;
                }
                primeiro:
                AnsiConsole.Markup("Digite o [red] ID de sua arma[/] inicial desejada: [underline red](tenha certeza que colocou o ID corretamente)[/] \n");
                //Console.WriteLine("Digite o ID de sua arma inicial desejada :");
                foreach (var arma in listArmas.ArmaList)
                {
                    Console.WriteLine($"ID: {arma.ID}| Nome: {arma.Qual}| Dano: {arma.Dano}");
                }
                string armaID = Console.ReadLine();

                bool teste = listArmas.ArmaList.Any(x => x.ID == int.Parse(armaID));

                if (teste==false)
                {
                    goto primeiro;
                    
                    
                }
                segundo:
                AnsiConsole.Markup("Digite o [red] ID de sua armadura[/] inicial desejada:[underline red](tenha certeza que colocou o ID corretamente)[/] \n");
                //Console.WriteLine("Digite o ID de sua armadura inicial desejada :");
                foreach (var armadura in listArmaduras.ArmaduraList)
                {
                    Console.WriteLine($"ID: {armadura.ID}| Nome: {armadura.Qual}| Defesa da armadura: {armadura.DanoAbs}");
                }
                string armaduraID = Console.ReadLine();

                bool teste2 = listArmaduras.ArmaduraList.Any(x => x.ID == int.Parse(armaduraID));

                if (teste2 == false)
                {
                    goto segundo;
                    //AnsiConsole.Markup("[underline red]ID Inválido, aperte enter e tente novamente...");
                    //Console.ReadLine();
                    //goto segundo;
                }
                terceiro:
                AnsiConsole.Markup("Digite o [red] ID de sua classe(seus atributos)[/] inicial desejada:[underline red](tenha certeza que colocou o ID corretamente)[/] \n");
                //Console.WriteLine("Digite o ID sua classe(seus atributos) desejado :");
                foreach (var atributo in listAtributos.AtributoList)
                {
                    Console.WriteLine($"ID: {atributo.ID}| Inteligência: {atributo.Inteligencia}| Força: {atributo.Força}| Fé: {atributo.Fe}| Energia: {atributo.Energia}| Defesa: {atributo.Defesa}| Vitalidade: {atributo.Vitalidade}| Vigor: {atributo.Vigor}| Magia: {atributo.Magia}");
                }
                string atributoID = Console.ReadLine();

                bool teste3 = listAtributos.AtributoList.Any(x => x.ID == int.Parse(atributoID));

                if (teste3 == false)
                {
                    goto terceiro;
                    //AnsiConsole.Markup("[underline red]ID Inválido, aperte enter e tente novamente...");
                    //Console.ReadLine();
                    //goto terceiro;
                }
                quarto:
                AnsiConsole.Markup("Digite o [red] ID d seu poder[/] inicial desejado:[underline red](tenha certeza que colocou o ID corretamente)[/] \n");
                //Console.WriteLine("Digite o ID do seu poder incial desejado :");
                foreach (var poder in listPoder.PoderList)
                {
                    Console.WriteLine($"ID: {poder.ID}| Poderes: {poder.Pod}");
                }
                string poderID = Console.ReadLine();
                bool teste4 = listPoder.PoderList.Any(x => x.ID == int.Parse(poderID));

                if (teste4 == false)
                {
                    goto quarto;
                    //AnsiConsole.Markup("[underline red]Inválido, aperte enter e tente novamente...");
                    //Console.ReadLine();
                    //goto quarto;
                }


                sqlConnection.Open();
                string insertQuerry = $"INSERT INTO Personagem(nome, idade, peso, sexo, itemIni, armaID, armaduraID, poderID, atributoID) VALUES('{nome}', {idade}, {peso}, '{sexo}', '{itemIni}', '{armaID}', '{armaduraID}', '{poderID}', '{atributoID}')";
                SqlCommand insertCommand = new SqlCommand(insertQuerry, sqlConnection);
                insertCommand.ExecuteNonQuery();
                Console.WriteLine("Novo personagem criado.... Aperte Enter para retornar....");
                sqlConnection.Close();
                Console.ReadLine();
            }
            catch (Exception)
            {
                AnsiConsole.Markup("[underline red]Entrada Inválida...aperte enter para tentar novamente[/]");
                //Console.WriteLine("Entrada Inválida...aperte entre para tentar novamente");
                Console.ReadLine();
                goto voltar;
            }




        }

    }
}

