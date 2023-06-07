using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace SistemaNumerosIntermediario
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;
            const int tam = 10000;
            int[] vetor = new int[tam];
            Console.ForegroundColor = ConsoleColor.Green;
            do
            {
                opcao = Menu(opcao);
                vetor = GerenciaOpcao(opcao, vetor);
            } while (opcao != 0);
        }

        static int Menu(int opcao)
        {
            bool errado;
            Console.WriteLine(" _____________________________");
            Console.WriteLine("|                             |");
            Console.WriteLine("|      SISTEMA NÚMEROS        |");
            Console.WriteLine("|                             |");
            Console.WriteLine("| Menu de opções:             |");
            Console.WriteLine("|                             |");
            Console.WriteLine("| 1. Gera Números Pares       |");
            Console.WriteLine("| 2. Gera Números Impares     |");
            Console.WriteLine("| 3. Gera Números Multiplos   |");
            Console.WriteLine("| 4. Lista Números Gerados    |");
            Console.WriteLine("| 5. Testa Número Primo       |");
            Console.WriteLine("| 6. Gera Números Primos      |");
            Console.WriteLine("| 7. Gera Palpite Megasena    |");
            Console.WriteLine("| 8. Gera Números Aleatórios  |");
            Console.WriteLine("| 0. Encerra este Sistema     |");
            Console.WriteLine("|_____________________________|\n");
            Console.Write("  Digite a opção desejada: ");
            errado = true;
            while (errado)
            {
                if (int.TryParse(Console.ReadLine(), out opcao))
                    if ((opcao < 0) || (opcao > 8))
                        Console.Write("Opção não existente. Digite opção desejada corretamente: ");
                    else errado = false;
                else Console.Write("Opção não numérica. Digite opção desejada corretamente: ");
            }
            /*while (!(int.TryParse(Console.ReadLine(), out opcao)))
                Console.Write("Opção não numérica. Digite opção desejada: ");*/
            Console.WriteLine("\n");
            return opcao;
        }

        static int[] GerenciaOpcao(int opcao, int[] vetor)
        {
            int aux, num;
            switch (opcao)
            {
                case 1:
                    vetor = GeraPares();
                    break;
                case 2:
                    vetor = GeraImpares();
                    break;
                case 3:
                    vetor = GeraMultiplos();
                    break;
                case 4:
                    aux = Lista(vetor);
                    Console.WriteLine("\n\nForam listados " + aux + " números.");
                    break;
                case 5:
                    Console.Write("Qual número deseja testar se é primo? ");
                    while (!(int.TryParse(Console.ReadLine(), out num)))
                        Console.Write("Número inválido! Digite um número inteiro para testar: ");
                    aux = TestaPrimo(num);
                    if (aux == 0)
                        Console.WriteLine("O número {0} é primo, pois só é divisível por 1 e por ele mesmo.", num);
                    else
                        Console.WriteLine("O número {0} não é primo, pois é divisível por {1}, além de outros.", num, aux);
                    break;
                case 6:
                    vetor = GeraPrimos();
                    break;
                case 7:
                    vetor = GeraSena();
                    break;
                case 8:
                    vetor = GeraAleatorios();
                    break;
                case 0:
                    Console.WriteLine("Obrigado por utilizar o Sistema Números!");
                    break;
                    //default: // como a opção indicado pelo usuário já foi consistida, não precisa desta clausula default
                    //  Console.WriteLine("Opção inexistente!");
                    //break;
            }//fim do switch
            Console.Write("Pressione qualquer tecla para prosseguir");
            Console.ReadKey();
            Console.Clear();
            return vetor;
        }

        static int[] GeraPares()
        {
            int i, qtd, num, tam = 10000;
            int[] vetorAux = new int[tam];
            bool paradinha = true;
            Console.Clear();
            Console.WriteLine("Sistema Números\n\nGeração de números pares:\n");
            Console.Write("Quanto números pares listar? ");
            while (!(int.TryParse(Console.ReadLine(), out qtd)))
                Console.Write("Quantidade inválida! Digite quantidade desejada: ");
            if (qtd > 9999)
            {
                Console.WriteLine("Para que não haja estouro do vetor, o limite máximo é 9999! Esse será a quantidade assumida.");
                qtd = 9999;
            }
            for (i = 1; i < tam; i++) // Limpa vetor
                vetorAux[i] = 0;
            i = 1;
            while (i <= qtd)
            {
                num = i * 2;
                paradinha = Listar(num, i, paradinha, i == qtd);
                vetorAux[i] = num;
                i++; // i = i + 1;
            }
            Console.WriteLine("\n");
            return vetorAux;
        }

        static int[] GeraImpares()
        {
            int i, qtd, num, tam = 10000;
            int[] vetorAux = new int[tam];
            bool paradinha = true;
            Console.Clear();
            Console.WriteLine("Sistema Números\n\nGeração de números impares:\n");
            Console.Write("Quanto números impares listar? ");
            while (!(int.TryParse(Console.ReadLine(), out qtd)))
                Console.Write("Quantidade inválida! Digite quantidade desejada: ");
            if (qtd > 9999)
            {
                Console.WriteLine("Para que não haja estouro do vetor, o limite máximo é 9999! Esse será a quantidade assumida.");
                qtd = 9999;
            }
            for (i = 1; i < tam; i++) // Limpa vetor
                vetorAux[i] = 0;
            i = 0;
            do
            {
                num = i * 2 + 1;
                i++;
                paradinha = Listar(num, i, paradinha, i == qtd);
                vetorAux[i] = num;
            } while (i < qtd);
            Console.WriteLine("\n");
            return vetorAux;
        }

        static int[] GeraMultiplos()
        {
            int aux, num, i, qtd, tam = 10000;
            int[] vetorAux = new int[tam];
            bool paradinha = true;
            Console.Clear();
            Console.WriteLine("Sistema Números\n\nGeração de números multiplos:\n");
            Console.Write("Multiplo de qual número inteiro? ");
            while (!(int.TryParse(Console.ReadLine(), out aux)))
                Console.Write("Não é um número inteiro! Digite número inteiro do qual deseja gerar multiplos: ");
            Console.Write("Quanto números multiplos listar? ");
            while (!(int.TryParse(Console.ReadLine(), out qtd)))
                Console.Write("Quantidade inválida! Digite quantidade desejada: ");
            if (qtd > 9999)
            {
                Console.WriteLine("Para que não haja estouro do vetor, o limite máximo é 9999! Esse será a quantidade assumida.");
                qtd = 9999;
            }
            for (i = 1; i < tam; i++) // Limpa vetor
                vetorAux[i] = 0;
            for (i = 1; i <= qtd; i++)
            {
                num = i * aux;
                paradinha = Listar(num, i, paradinha, i == qtd);
                vetorAux[i] = num;
            }
            Console.WriteLine("\n");
            return vetorAux;
        }

        static int Lista(int[] vetor)
        {
            int i, j, aux, tam = 10000;
            Stopwatch gasto = new Stopwatch();
            string decorrido;
            bool paradinha = true;
            Console.Clear();
            Console.WriteLine("Sistema Números\n\nListagem dos últimos números gerados:\n");
            if (vetor[1] == 0) // não tem nada para ser listado
            {
                Console.WriteLine("Não tem nada para ser listado! Listagem será encerrada.");
                return 0;
            }
            for (i = 1; i <= tam && vetor[i] != 0; i++)
                paradinha = Listar(vetor[i], i, paradinha, i == tam);
            return i - 1;
        }

        static bool Listar(int x, int pos, bool paradinha, bool ultimo)
        {
            char tecla;
            if (pos == 1) { Console.Write("Linha {0:0000}:\t", pos); paradinha = true; }
            if (pos % 10 == 0)
            {
                Console.Write("{0}\n", x);
                if (pos % 100 == 0)
                    if (paradinha)
                    {
                        Console.Write("\nDeseja dar uma paradinha a cada 10 linhas listadas?(Digite n para não): ");
                        tecla = Console.ReadKey().KeyChar;
                        if (tecla == 'n' || tecla == 'N')
                        {
                            paradinha = false;
                            Console.WriteLine();
                        }
                        else paradinha = true;
                        if (!ultimo) Console.Write("Linha {0:0000}:\t", (pos / 10 + 1)); else;
                    }
                    else
                        if (!ultimo) Console.Write("Linha {0:0000}:\t", (pos / 10 + 1)); else;
                else
                    if (!ultimo) Console.Write("Linha {0:0000}:\t", (pos / 10 + 1)); else;
            }
            else
                Console.Write("{0}\t", x);
            return paradinha;
        }

        static int TestaPrimo(int num)
        {
            int i, div = 0;
            for (i = 2; i <= num / 2; i++)
                if (num % i == 0)
                {
                    div = i;
                    break; //ou i = num;
                }
            num = div;
            return num;
        }

        static int[] GeraPrimos()
        {
            int i, j = 1, qtd, tam = 10000;
            int[] vetorAux = new int[tam];
            bool paradinha = true;
            Console.Clear();
            Console.WriteLine("Sistema Números\n\nGeração de números primos:\n");
            Console.Write("Quanto números primos listar? ");
            while (!(int.TryParse(Console.ReadLine(), out qtd)))
                Console.Write("Quantidade inválida! Digite quantidade desejada: ");
            if (qtd > 9999)
            {
                Console.WriteLine("Para que não haja estouro do vetor, o limite máximo é 9999! Esse será a quantidade assumida.");
                qtd = 9999;
            }
            for (i = 1; i < tam; i++) // Limpa vetor
                vetorAux[i] = 0;
            for (i = 1; i <= qtd; i++)
            {
                while (TestaPrimo(j) > 0)
                {
                    j++;
                }
                paradinha = Listar(j, i, paradinha, i == qtd);
                vetorAux[i] = j;
                j++;
            }
            Console.WriteLine("\n");
            return vetorAux;
        }

        static int[] GeraSena()
        {
            Random numAleatorio = new Random();
            int i, num, qtd, tam = 10000;
            int[] vetorAux = new int[tam];
            bool paradinha = true;
            Console.Clear();
            Console.WriteLine("Sistema Números\n\nGeração de dezenas para Megasena:\n");
            Console.Write("Quantas dezenas listar (de 6 a 15)? ");
            while (!(int.TryParse(Console.ReadLine(), out qtd)))
                Console.Write("Quantidade inválida! Digite quantidade desejada: ");
            if (qtd > 60)
            {
                Console.WriteLine("Para que não haja repetição, o limite máximo é 60! Esse será a quantidade assumida.");
                qtd = 60;
            }
            for (i = 1; i < tam; i++) // Limpa vetor
                vetorAux[i] = 0;
            for (i = 1; i <= qtd; i++)
            {
                num = numAleatorio.Next(1, 61);
                while (repetido(num, vetorAux, i))
                    num = numAleatorio.Next(1, 61);
                paradinha = Listar(num, i, paradinha, i == qtd);
                vetorAux[i] = num;
            }
            Console.WriteLine("\n\nUma aposta com {0} dezenas custa R$ {1}.", qtd, QuantoCustara(qtd));
            Console.WriteLine("\n");
            return vetorAux;
        }

        static bool repetido(int num, int[] vetor, int i)
        {
            int j;
            bool resp = false;
            for (j = 1; j < i; j++)
                if (num == vetor[j])
                {
                    j = i;
                    resp = true;
                }
            return resp;
        }

        static string QuantoCustara(int num)
        {
            string valor;
            switch (num)
            {
                case 6:
                    valor = "4,50";
                    break;
                case 7:
                    valor = "31,50";
                    break;
                case 8:
                    valor = "126,00";
                    break;
                case 9:
                    valor = "378,00";
                    break;
                case 10:
                    valor = "945,00";
                    break;
                case 11:
                    valor = "2.079,00";
                    break;
                case 12:
                    valor = "4.158,00";
                    break;
                case 13:
                    valor = "7.722,00";
                    break;
                case 14:
                    valor = "13.513,50";
                    break;
                case 15:
                    valor = "22.522,50";
                    break;
                default:
                    valor = "? (não é possível aposta com essa quantidade de dezenas)";
                    break;
            }
            return valor;
        }

        static void Tempo(string[] args)
        {
            Stopwatch gasto = new Stopwatch();
            gasto.Start();
            Thread.Sleep(10000);
            gasto.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = gasto.Elapsed;

            // Format and display the TimeSpan value.
            string decorrido = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("Tempo gasto: " + decorrido);
        }

        static int[] GeraAleatorios()
        {
            Random numAleatorio = new Random();
            int i, num, qtd, tam = 10000, max;
            int[] vetorAux = new int[tam];
            bool paradinha = true, comRepeticao = false;
            char resp = ' ';
            Console.Clear();
            Console.WriteLine("Sistema Números\n\nGeração de números aleatórios:\n");
            Console.Write("Quantas números listar (máximo 9.999)? ");
            while (!(int.TryParse(Console.ReadLine(), out qtd)))
                Console.Write("Quantidade inválida! Digite quantidade desejada: ");
            if (qtd > 9999)
            {
                Console.WriteLine("Para que não haja estouro do vetor, o limite máximo é 9999! Esse será a quantidade assumida.");
                qtd = 9999;
            }
            Console.Write("Gerar números de 1 até quanto? (máximo 9.999.999): ");
            while (!(int.TryParse(Console.ReadLine(), out max)))
                Console.Write("Quantidade inválida! Digite quantidade válida: ");
            if (max > 9999999)
            {
                Console.WriteLine("Para respeitar o limite máximo, este será 9999999!");
                max = 9999999;
            }
            Console.Write("Aceita números aleatórios repetidos? (s/n): ");
            while (!char.TryParse(Console.ReadLine(), out resp) || (resp != 's' && resp != 'S' && resp != 'n' && resp != 'N'))
                Console.Write("Digite apenas s ou n: ");
            if (resp == 's') comRepeticao = true;
            if (!comRepeticao && max < qtd)
            {
                Console.WriteLine("Como optou por não repetir, o limite máximo do número aleatório será o mesmo da quantidade desejada!");
                max = qtd;
            }
            for (i = 1; i < tam; i++) // zerando todas células do vetor
                vetorAux[i] = 0;
            //Console.Write("Quantas números listar (máximo 9.999)? ");
            for (i = 1; i <= qtd; i++)
            {
                num = numAleatorio.Next(1, max + 1);
                if (!comRepeticao)
                    while (repetido(num, vetorAux, i))
                        num = numAleatorio.Next(1, max + 1);
                paradinha = Listar(num, i, paradinha, i == qtd);
                vetorAux[i] = num;
            }
            Console.WriteLine("\n");
            return vetorAux;
        }
    }
}

