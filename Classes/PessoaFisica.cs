using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgBackEnd.Interfaces;

namespace ProgBackEnd.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        
        public string? cpf{get; set;}

        public string? dataNasc{get; set;}

        public string caminho { get; private set; } = "Database/PessoaFisica.csv"; 
        public override float CalcularImposto(float rendimento)
        {

            if (rendimento <= 1500)
            {
                return 0;
            }
            else if (rendimento > 1500 && rendimento <= 3500)
            {
                float resultado = (rendimento / 100) * 2;
                return resultado;
            }
            else if (rendimento > 1500 && rendimento <= 3500)
            {
                float resultado = (rendimento / 100) * 3.5f;
                return resultado;
            }
            else
            {
                float resultado = (rendimento / 100) * 5;
                return resultado;
            }


            
        }

        public bool ValidarDataNasc(DateTime dataNasc)
        {
            DateTime dataAtual = DateTime.Today;
            double anos = (dataAtual - dataNasc).TotalDays / 365;

            //Console.WriteLine(anos);
            
            if (anos >= 18)
            {
                return true;
            }
            return false;
        }

        public bool ValidarDataNasc(string dataNasc)
        {

            if(DateTime.TryParse( dataNasc, out DateTime dataConvertida ))
            {
                DateTime dataAtual = DateTime.Today;
                double anos = (dataAtual - dataConvertida).TotalDays / 365;

                Console.WriteLine(anos);
            
                if (anos >= 18)
                {
                    return true;
                }
                return false;
            }   
            return false;

            
        }

        public bool ValidarDataNascimento(string dataNasc)
        {
            DateTime dataConvertida;
            //verificar se a string esta em um fomato valido
            if(DateTime.TryParse(dataNasc, out dataConvertida)){//TryParse tenta converter e coloca na saida out
                //Console.WriteLine($"{dataConvertida}");
                DateTime dataAtual = DateTime.Today;
                double anos = (dataAtual - dataConvertida).TotalDays /365;
                if(anos >= 18){
                    return true;
                }
                return false;
            }
            return false;  
        }

        public void Inserir(PessoaFisica pf)
        {
            VerificarPastaArquivo(caminho);

            string[] pjString = {$"{pf.nome},{pf.cpf},{pf.dataNasc},{pf.rendimento},{pf.endereco.logradouro},{pf.endereco.numero},{pf.endereco.complemento},{pf.endereco.endComercial}"};

            File.AppendAllLines(caminho, pjString);
        }

        public List<PessoaFisica> Ler()
        {
            VerificarPastaArquivo(caminho);

            List<PessoaFisica> ListaPf = new List<PessoaFisica>();

            string[] linhas = File.ReadAllLines(caminho);


            foreach (string cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(",");

                PessoaFisica cadaPf = new PessoaFisica();
                Endereco cadaEnd = new Endereco();

                cadaPf.nome = atributos[0];
                cadaPf.cpf = atributos[1];
                cadaPf.dataNasc = atributos[2];
                cadaPf.rendimento = float.Parse(atributos[3]);
                cadaEnd.logradouro = atributos[4];
                cadaEnd.numero = int.Parse(atributos[5]);
                cadaEnd.complemento = atributos[6];
                cadaEnd.endComercial = bool.Parse(atributos[7]);
                cadaPf.endereco = cadaEnd;
                ListaPf.Add(cadaPf);
            }
            return ListaPf;
        }

    }
}
