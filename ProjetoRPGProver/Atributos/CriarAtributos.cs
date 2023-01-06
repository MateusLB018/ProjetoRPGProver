using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using ProjetoRPGProver.Contexto;
using ProjetoRPGProver.Models;
using ProjetoRPGProver.Services;
using Spectre.Console;

namespace ProjetoRPGProver.Atributos
{
    public class CriarAtributos
    {
        public static void Criando()
        {
            string connectionString = @"Data Source=.;Initial Catalog=PersonagemDB;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            ListAtributos ListaCria = new ListAtributos();
            ListaCria.ListAtribu();


            int inteligencia, forca, fe, vitalidade, energia, magia, defesa, vigor;
            string respot = "";

        inicio:
            Console.Clear();
            try
            {
                int numero = 27;
                AnsiConsole.Markup("Escolha o status de sua classe:  \n");
            //Console.WriteLine("Escolha o status de sua classe:  ");
            novamente1:
                Console.Clear();
                AnsiConsole.Markup($"Você tem :  [red]{ numero}[/] pontos para gastar \n");
                //Console.WriteLine("Você tem : " + numero + " de pontos para gastar");
                AnsiConsole.Markup("[purple]Inteligência:  [/]");
                //Console.Write("inteligencia: ");
                inteligencia = Convert.ToInt32(value: Console.ReadLine());
                if (inteligencia > 27)
                {
                    inteligencia = 0;
                    AnsiConsole.Markup("[underline red]Desculpe, número insuficiente de pontos...aperte enter para tentar novamente  \n[/]");
                    Console.ReadLine();
                    //Console.WriteLine("Desculpe, número insuficiente de pontos ");
                    goto novamente1;
                }
                if (inteligencia < 0)
                {
                    AnsiConsole.Markup("[underline red] Inválido, digite novamente  \n[/]");
                    Console.ReadLine();
                    //Console.WriteLine("Inválido, digite novamente...");
                    goto novamente1;
                }

                numero = numero - inteligencia;

                if (numero == 0)
                {
                    forca = 0;
                    fe = 0;
                    vitalidade = 0;
                    energia = 0;
                    magia = 0;
                    defesa = 0;
                    vigor = 0;
                    goto fim;
                }
            novamente2:
                AnsiConsole.Markup($"Você tem :  [red]{ numero}[/] pontos para gastar \n");
                AnsiConsole.Markup("[purple]Força:  [/]");
                forca = Convert.ToInt32(Console.ReadLine());
                if (forca > numero)
                {
                    forca = 0;
                    AnsiConsole.Markup("[underline red]Desculpe, número insuficiente de pontos...aperte enter para tentar novamente  \n[/]");
                    Console.ReadLine();
                    goto novamente2;
                }
                if (forca < 0)
                {
                    AnsiConsole.Markup("[underline red] Inválido, digite novamente  \n[/]");
                    Console.ReadLine();
                    goto novamente2;
                }
                numero = numero - forca;

                if (numero == 0)
                {
                    fe = 0;
                    vitalidade = 0;
                    energia = 0;
                    magia = 0;
                    defesa = 0;
                    vigor = 0;
                    goto fim;
                }

            novamente3:
                AnsiConsole.Markup($"Você tem :  [red]{ numero}[/] pontos para gastar \n");
                AnsiConsole.Markup("[purple]Fe:  [/]");
                fe = Convert.ToInt32(Console.ReadLine());
                if (fe > numero)
                {
                    fe = 0;
                    AnsiConsole.Markup("[underline red]Desculpe, número insuficiente de pontos...aperte enter para tentar novamente  \n[/]");
                    Console.ReadLine();
                    goto novamente3;
                }
                if (fe < 0)
                {
                    AnsiConsole.Markup("[underline red] Inválido, digite novamente  \n[/]");
                    Console.ReadLine();
                    goto novamente3;
                }
                numero = numero - fe;

                if (numero == 0)
                {
                    vitalidade = 0;
                    energia = 0;
                    magia = 0;
                    defesa = 0;
                    vigor = 0;
                    goto fim;
                }

            novamente4:
                AnsiConsole.Markup($"Você tem :  [red]{ numero}[/] pontos para gastar \n");
                AnsiConsole.Markup("[purple]Vitalidade:  [/]");
                vitalidade = Convert.ToInt32(Console.ReadLine());
                if (vitalidade > numero)
                {
                    vitalidade = 0;
                    AnsiConsole.Markup("[underline red]Desculpe, número insuficiente de pontos...aperte enter para tentar novamente  \n[/]");
                    Console.ReadLine();
                    goto novamente4;
                }
                if (vitalidade < 0)
                {
                    AnsiConsole.Markup("[underline red] Inválido, digite novamente  \n[/]");
                    Console.ReadLine();
                    goto novamente4;
                }
                numero = numero - vitalidade;

                if (numero == 0)
                {
                    energia = 0;
                    magia = 0;
                    defesa = 0;
                    vigor = 0;
                    goto fim;
                }

            novamente5:
                AnsiConsole.Markup($"Você tem :  [red]{ numero}[/] pontos para gastar \n");
                AnsiConsole.Markup("[purple]Energia:  [/]");
                energia = Convert.ToInt32(Console.ReadLine());
                if (energia > numero)
                {
                    energia = 0;
                    AnsiConsole.Markup("[underline red]Desculpe, número insuficiente de pontos...aperte enter para tentar novamente  \n[/]");
                    Console.ReadLine();
                    goto novamente5;
                }
                if (energia < 0)
                {
                    AnsiConsole.Markup("[underline red] Inválido, digite novamente  \n[/]");
                    Console.ReadLine();
                    goto novamente5;
                }
                numero = numero - energia;

                if (numero == 0)
                {
                    magia = 0;
                    defesa = 0;
                    vigor = 0;
                    goto fim;
                }

            novamente6:
                AnsiConsole.Markup($"Você tem :  [red]{ numero}[/] pontos para gastar \n");
                AnsiConsole.Markup("[purple]magia:  [/]");
                magia = Convert.ToInt32(Console.ReadLine());
                if (magia > numero)
                {
                    magia = 0;
                    AnsiConsole.Markup("[underline red]Desculpe, número insuficiente de pontos...aperte enter para tentar novamente  \n[/]");
                    Console.ReadLine();
                    goto novamente6;
                }
                if (magia < 0)
                {
                    AnsiConsole.Markup("[underline red] Inválido, digite novamente  \n[/]");
                    Console.ReadLine();
                    goto novamente6;
                }
                numero = numero - magia;

                if (numero == 0)
                {
                    defesa = 0;
                    vigor = 0;
                    goto fim;
                }

            novamente7:
                AnsiConsole.Markup($"Você tem :  [red]{ numero}[/] pontos para gastar \n");
                AnsiConsole.Markup("[purple]Defesa:  [/]");
                defesa = Convert.ToInt32(Console.ReadLine());
                if (defesa > numero)
                {
                    defesa = 0;
                    AnsiConsole.Markup("[underline red]Desculpe, número insuficiente de pontos...aperte enter para tentar novamente  \n[/]");
                    Console.ReadLine();
                    goto novamente7;
                }
                if (defesa < 0)
                {
                    AnsiConsole.Markup("[underline red] Inválido, digite novamente  \n[/]");
                    Console.ReadLine();
                    goto novamente7;
                }
                numero = numero - defesa;


                if (numero == 0)
                {
                    vigor = 0;
                    goto fim;
                }

            novamente8:
                AnsiConsole.Markup($"Você tem :  [red]{ numero}[/] pontos para gastar \n");
                AnsiConsole.Markup("[purple]Vigor:  [/]");
                vigor = Convert.ToInt32(Console.ReadLine());
                if (vigor > numero)
                {
                    vigor = 0;
                    AnsiConsole.Markup("[underline red]Desculpe, número insuficiente de pontos...aperte enter para tentar novamente  \n[/]");
                    Console.ReadLine();
                    goto novamente8;
                }
                if (vigor < 0)
                {
                    AnsiConsole.Markup("[underline red] Inválido, digite novamente  \n[/]");
                    Console.ReadLine();
                    goto novamente8;
                }
                numero = numero - vigor;

            fim:
               // AnsiConsole.Markup($"Seus atributos são : " + "\ninteligencia: " + inteligencia + "\nforça: " + forca + "\nfe: " + fe + "\nvitalidade: " + vitalidade + "\nenergia: " + energia + "\nmagia: " + magia + "\ndefesa: " + defesa + "\nvigor: " + vigor \n");
                AnsiConsole.Markup($"Seus atributos são : \n[purple]Inteligência:[/] [red]{inteligencia}[/] \n[purple]Força:[/] [red]{forca}[/]\n[purple]Fé:[/] [red]{fe}[/]\n[purple]Vitalidade:[/] [red]{vitalidade}[/]\n[purple]Energia:[/] [red]{energia}[/]\n[purple]Magia:[/] [red]{magia}[/]\n[purple]Defesa:[/] [red]{defesa}[/]\n[purple]Vigor:[/] [red]{vigor}[/]\n");
                //Console.WriteLine("Seus atributos são : " + "\ninteligencia: " + inteligencia + "\nforça: " + forca + "\nfe: " + fe + "\nvitalidade: " + vitalidade + "\nenergia: " + energia + "\nmagia: " + magia + "\ndefesa: " + defesa + "\nvigor: " + vigor);
                //Console.WriteLine("Está feliz com sua decisão ?");
                var nice3 = AnsiConsole.Confirm("\nEstá feliz com a [underline red]sua decisão[/] ?\n ");
                
                //Console.WriteLine("--------->s///////////---------->n");
                //respot = Console.ReadLine();
                if (nice3==true)
                {
                    sqlConnection.Open();
                    string insertQuerry = $"INSERT INTO Atributo(inteligencia, força, fe, vitalidade, energia, magia, defesa, vigor)VALUES('{inteligencia}',{forca},{fe},{vitalidade},{energia},{magia},{defesa},{vigor})";
                    SqlCommand insertCommand = new SqlCommand(insertQuerry, sqlConnection);
                    insertCommand.ExecuteNonQuery();
                    Console.WriteLine("Atributos selecionados.... Aperte Enter para retornar....");
                    sqlConnection.Close();
                    Console.ReadLine();
                    
                }
                else 
                {
                    goto inicio;
                }
                
            }
            catch (Exception)
            {
                AnsiConsole.Markup("[underline red]Entrada Inválida...aperte enter para tentar novamente[/]");
                Console.ReadLine();
                goto inicio;
            }




        }
    }
}

