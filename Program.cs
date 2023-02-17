// See https://aka.ms/new-console-template for more information

//Console.Clear();
//Console.WriteLine("Hello, World!");
//Console.WriteLine("Turma13");

using ProgBackEnd.Classes;


Console.Clear();

Utils.BarraCarregamento("iniciando", 3, ".");

List<PessoaFisica> listaPf = new List<PessoaFisica>();
List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

string? opcao;

do
{   
    Console.Clear();
    Console.WriteLine(@$"
    
    ==================================================
    |         Bem-Vindo ao Sistema de Cadastro       |
    |           de Pessoa Física ou Juridica         |
    ==================================================
    |        Digite o número da opção desejada       |
    ==================================================
    |                                                |
    |               1-Pessoa Física                  |
    |               2-Pessoa Juridica                |
    |                                                |
    |               0-Sair                           |
    ==================================================
");


opcao = Console.ReadLine();
Thread.Sleep(1000);

        switch (opcao)
        {
            case "1":

                    


                    string? opcaoPf;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine(@$"
    

    ==================================================
    |        Digite o número da opção desejada       |
    ==================================================
    |                                                |
    |            1-Cadastrar Pessoa Fisica           |
    |            2-Mostrar Pessoas Fisicas           |
    |                                                |
    |            0-Voltar ao menu anterior           | 
    ==================================================
");
                
                     opcaoPf = Console.ReadLine();

                    PessoaFisica metodoPf = new PessoaFisica();
                    PessoaFisica novaPf = new PessoaFisica();
                    Endereco novaEndPF = new Endereco();
            
                   switch (opcaoPf)
                   {
                    case "1":
                        Console.Clear();
                       
                        
                        Console.WriteLine($"Digite o nome da pessoa fisica que deseja cadastrar:");
                        novaPf.nome = Console.ReadLine();
           
                        bool dataValida;
                        do
                        {
                            Console.WriteLine($"Digite a data de nascimento:");
                            string? dataNasc = Console.ReadLine();
                            
                            dataValida = metodoPf.ValidarDataNasc(dataNasc);

                            if (dataValida)
                            {
                                novaPf.dataNasc = dataNasc;
                            }
                            else{
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"Data digitada invalida, por favor digite uma outra data");
                                Console.ResetColor();
                            }

                        } while (dataValida == false); 

                        Console.WriteLine($"Digite o número do cpf:");
                        novaPf.cpf = Console.ReadLine();

                        Console.WriteLine($"Digite o rendimento mensal (apenas números):");
                        novaPf.rendimento = float.Parse(Console.ReadLine());
                        
                        Console.WriteLine($"Digita o logradouro:");
                        novaEndPF.logradouro = Console.ReadLine();
                       
                        Console.WriteLine($"Digite o número:");
                        novaEndPF.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento (aperte ENTER para vazio):");
                        novaEndPF.complemento = Console.ReadLine();

                        Console.WriteLine($"Esse endereço é comercial? S ou N");
                        string endCom = Console.ReadLine().ToUpper();
                        if (endCom == "S")
                        {
                            novaEndPF.endComercial = true;
                        }else{
                            novaEndPF.endComercial = false;
                        }

                        novaPf.endereco = novaEndPF;
                       
                        // using (StreamWriter sw = new StreamWriter($"{novaPf.nome}.txt"))
                        // {
                        //     sw.WriteLine(novaPf.nome);
                        //     sw.WriteLine(novaPf.dataNasc);
                        //     sw.WriteLine(novaPf.cpf);
                        //     sw.WriteLine(novaPf.rendimento);
                        //     sw.WriteLine(novaEndPF.logradouro);
                        //     sw.WriteLine(novaEndPF.numero);
                        //     sw.WriteLine(novaEndPF.complemento);
                        //     sw.WriteLine(novaEndPF.endComercial);

                        // }    AQUI EM CIMA ESTA O CODIGO PARA CRIAR O AQUIVO TXT, APENSA DEIXEI DESATIVADO
                    

                        metodoPf.Inserir(novaPf);

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Cadastro Realizado com sucesso!!!");
                        Thread.Sleep(3000);
                        Console.ResetColor();

                        break;
                    case "2":

                        Console.Clear();
                             List<PessoaFisica> ListaPf = metodoPf.Ler();
                        
                            foreach (PessoaFisica cadaPessoa in ListaPf)
                            {
                                Console.WriteLine(@$"
                                Nome: {cadaPessoa.nome}
                                Data de Nascimento: {cadaPessoa.dataNasc}
                                CPF: {cadaPessoa.cpf}
                                Rendimento: {cadaPessoa.rendimento.ToString("C")}
                                Logradouro: {cadaPessoa.endereco.logradouro}
                                Número: {cadaPessoa.endereco.numero}
                                Complemento: {cadaPessoa.endereco.complemento}
                                Endereço Comercial? {((bool)(cadaPessoa.endereco.endComercial)?"Sim":"Não")}
                                Taxa de Imposto a ser paga: {cadaPessoa.CalcularImposto(cadaPessoa.rendimento).ToString("C")}
                                ");
                                
                            }

                        
                            // using (StreamReader sr = new StreamReader("Jhony.txt"))
                            // {
                            //     string linha;
                            //     while ((linha = sr.ReadLine()) != null)
                            //     {
                            //         Console.WriteLine($"{linha}");
                            //     }
                             
                            //    Console.WriteLine($"Aperte 'Enter' para continuar....");
                            //    Console.ReadLine();
                            // } (APENAS DESATIVADO)

                            Console.WriteLine($"Aperte 'Enter' para continuar");
                            Console.ReadLine();

                                
                                    
                        break;

                    case "0":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"Opção invalida, por favor digite outra opção");
                        Thread.Sleep(3000);
                        break;
                   }
                   
                    } while (opcaoPf != "0");




                break;

            case "2":
                    string? opcaoPj;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine(@$"

    ==================================================
    |        Digite o número da opção desejada       |
    ==================================================
    |                                                |
    |            1-Cadastrar Pessoa Juridica         |
    |            2-Mostrar Pessoas Juridica          |
    |                                                |
    |            0-Voltar ao menu anterior           | 
    ==================================================
");
                
                    opcaoPj = Console.ReadLine();


                    PessoaJuridica metodoPj = new PessoaJuridica();
                    PessoaJuridica novaPj = new PessoaJuridica();
                    Endereco novoEndPj = new Endereco();
                  
                    
                    switch (opcaoPj)
                    {
                        case "1":
                            Console.Clear();
                            
                        

                        Console.WriteLine($"Digite o nome da pessoa juridica que deseja cadastrar");
                        novaPj.nome = Console.ReadLine();
                        

                        bool cnpjValido;
                        do
                        {
                            Console.WriteLine($"Digite o CNPJ Ex.: 00.000.000/0001-00 ou 00000000000000");
                            string cnpj = Console.ReadLine();

                            cnpjValido = metodoPj.ValidarCnpj(cnpj);
                            if(cnpjValido)
                            {
                                novaPj.cnpj = cnpj;
                            }
                            else{
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"Cnpj Inválido, por favor digite um cnpj valido.");
                                Console.ResetColor();
                                
                            } 
                        } while (cnpjValido == false);

                        Console.WriteLine($"Digite a razao social");
                        novaPj.razaoSocial = Console.ReadLine();

                        Console.WriteLine($"Digite o rendimento mensal (digite apenas números)");
                        novaPj.rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o logradouro:");
                        novoEndPj.logradouro = Console.ReadLine();
                       
                        Console.WriteLine($"Digite o numero:");
                        novoEndPj.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemetento (Aperte ENTER para vazio)");
                        novoEndPj.complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é comercial? S ou N");
                        string endCom = Console.ReadLine().ToUpper();
                            
                        if (endCom == "S"){
                            novoEndPj.endComercial = true;
                        }
                        else{
                            novoEndPj.endComercial = false;
                        }
                        novaPj.endereco = novoEndPj;
  
                    
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Cadastro Realizado com sucesso!!!");
                        Thread.Sleep(3000);
                        Console.ResetColor();

                          
                        
                        metodoPj.Inserir(novaPj);
                            break;
                        case "2":

                              List<PessoaJuridica> ListaPj = metodoPj.Ler();

                              foreach(PessoaJuridica cadaItem in ListaPj)
                        {
                            Console.Clear();
                           
                            
                            Console.WriteLine(@$"
                                Nome: {cadaItem.nome}   
                                CNPJ: {cadaItem.cnpj}
                                Razao Social: {cadaItem.razaoSocial}
                                Rendimento: {cadaItem.rendimento}
                                Imposto: {metodoPj.CalcularImposto(cadaItem.rendimento).ToString("C")}
                                Logradouro: {cadaItem.endereco.logradouro}
                                Número: {cadaItem.endereco.numero}
                                Complemento: {cadaItem.endereco.complemento}
                                Endereço Comercial?:{((cadaItem.endereco.endComercial)?"Sim":"Não")}
                            ");
                            
                            Console.WriteLine($"Aperte 'Enter' para continuar");
                            Console.ReadLine();
                           
                        }
                        break;
                    case "0":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"Opção invalida, por favor digite outra opção");
                        Thread.Sleep(3000);
                        break;
                   }
                  
                    } while (opcaoPj != "0");

                break;

            case "0":

                Console.WriteLine($"Obrigado por utilizar nosso sistema");
                
                break;

            default:

            Console.WriteLine("Opção invalida, digite um valor disponivel");
            Console.WriteLine($"Para continuar, aperte a tecla ENTER");
            Console.ReadLine();
            
                break;
        }

} while (opcao != "0");

Utils.BarraCarregamento("Finalizando", 9, ".");