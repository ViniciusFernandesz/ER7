using System;
using System.Threading;
using System.Collections.Generic;

namespace EncontroRemoto
{
   class Program
   {
       static void Main(string[] args)
       {

           List<PessoaFisica> ListaPf = new List<PessoaFisica>();
           Console.Clear();
           Console.ForegroundColor = ConsoleColor.DarkGreen;
           Console.BackgroundColor = ConsoleColor.White;
           Console.WriteLine(@$"
========================================
|  Bem-vindo ao Sistema de Cadastro    |
|  de Pessoa Física e Pessoa Jurídica  |
========================================
");
            BarraCarregamento("Iniciando");

            string? opcao;
           
            do
            {
                Console.WriteLine(@$"
===================================
| Escolha uma das opções abaixo   |
|        PESSSOA FÍSICA           |
| 1 - Cadastrar Pessoa Física     |
| 2 - Listar Pessoa Física        |
| 3 = Remover Pessoa Física       |
|                                 | 
|         PESSOA JURÍDICA         |
| 4 - Cadastrar Pessoa Jurídica   |
| 5 - Listar Pessoa Jurídica      |
| 6 - Remover Pessoa Jurídica     |
|                                 |
|        0 - Sair                 |
===================================
");opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                    
                        Endereco endPF = new Endereco();

                        Console.WriteLine($"Digite seu logradouro");
                        endPF.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o número");
                        endPF.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento (aperta ENTER para vazio)");
                        endPF.complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é comercial? S/N");
                        string endComercial = Console.ReadLine().ToUpper();

                        if (endComercial == "S"){
                            endPF.enderecoComercial = true;
                        }else{
                            endPF.enderecoComercial = false;
                        }

                        PessoaFisica novapf = new PessoaFisica();

                        Console.WriteLine($"Digite seu CPF (somente números, para X digite 0)");
                        novapf.cpf = Console.ReadLine();

                        Console.WriteLine($"Digite seu nome");
                        novapf.nome = Console.ReadLine();
                        
                        Console.WriteLine($"Digite sua data de nascimento");
                        novapf.dataNascimento = DateTime.Parse(Console.ReadLine());
                        

                        PessoaFisica pf = new PessoaFisica();
                        //pf.ValidarDataNascimento(pf.dataNascimento);

                        Console.WriteLine(pf.PagarImposto(novapf.rendimento).ToString("N2"));
                        
                        bool idadeValida = pf.ValidarDataNascimento(novapf.dataNascimento);
                        Console.WriteLine(idadeValida);

                        if (idadeValida == true)
                        {
                            Console.WriteLine($"Cadastro Aprovado");
                            ListaPf.Add(novapf);
                            Console.WriteLine(pf.PagarImposto(novapf.rendimento));
                        }
                        else
                        {
                            Console.WriteLine($"Cadastro Não Aprovado");
                        }

                        //Console.WriteLine(pf.ValidarDataNascimento(novapf.dataNascimento));
                        //Console.WriteLine("Rua: " + novapf.endereco.logradouro + ", " + novapf.endereco.numero);
                        break;

                    case "2":
                    foreach (var cadaItem in ListaPf)
                    {
                        Console.WriteLine($"{cadaItem.nome}, {cadaItem.cpf}, {cadaItem.dataNascimento}");    
                    }
                        break;

                    case "3":

                    Console.WriteLine($"Digite o CPF que deseja remover");
                    string cpfProcurado = Console.ReadLine();
                    
                    PessoaFisica pessoaencontrada = ListaPf.Find(cadaItem => cadaItem.cpf == cpfProcurado);
                    if  (pessoaencontrada != null)
                    {
                        ListaPf.Remove(pessoaencontrada);
                        Console.WriteLine($"Cadastro Removido");
                    }else{
                        Console.WriteLine($"CPF não encontrado");
                    }
                        break;

                    case "4":

                        PessoaJuridica pj = new PessoaJuridica();

                        PessoaJuridica novapj = new PessoaJuridica();

                        Endereco endPJ = new Endereco();

                        endPJ.logradouro = "Rua Nova";
                        endPJ.numero = 745;
                        endPJ.complemento = "Perto da igreja Santa Terezinha";
                        endPJ.enderecoComercial = true;

                        novapj.endereco = endPJ;
                        novapj.cnpj = "1234567890001";
                        novapj.rendimento = 8000;
                        novapj.razaoSocial = "Pessoa Juridica";
                        
                        Console.WriteLine(pj.PagarImposto(novapj.rendimento).ToString("N2"));
                        break;

                    case "0":
                        Console.WriteLine($"Obrigado por utilizar o nosso sistema !");
                        BarraCarregamento("Finalizando");
                        break;

                    default:
                        Console.WriteLine($"Opção inválida, digite uma opção válida");

                        break;
                }
                
            } while (opcao != "0");                                   
        }

        static void BarraCarregamento(string textoCarregamento)
        {
            Console.ResetColor(); 
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(textoCarregamento);
            Thread.Sleep(500);


            for (var contador = 0; contador < 10; contador++)
            {
                
                Console.Write($".");
                Thread.Sleep(500);            
            }
            Console.ResetColor();  


        }
   }
}