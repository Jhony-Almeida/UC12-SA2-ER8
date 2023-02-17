using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ProgBackEnd.Interfaces;

namespace ProgBackEnd.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        
        public string? cnpj {get; set;}

        public string? razaoSocial {get; set;}

        public string caminho {get; private set;} = "Database/PessoaJuridica.csv";

        public override float CalcularImposto(float rendimento)
        {
            if (rendimento <= 3000)
            {
                return rendimento * 0.03f; //3%
            }
            else if (rendimento > 3000 && rendimento <= 6000)
            {
                return rendimento * 0.05f; //5%
            }
            else if (rendimento > 3000 && rendimento <= 6000)
            {
                return rendimento * 0.07f; //7%
            }
            else
            {
                return rendimento * 0.09f; //9%
            }

        }

        public bool ValidarCnpj(string cnpj)
        //xxxxxxxx0001xx
        //xx.xxx.xxx/0001-xx
        
        {
            bool retornoCnpjValido = Regex.IsMatch(cnpj,@"^(\d{14})|(\d}{2}.\d{3}.\d{3}.\d{4}-\{2})$");

            if (retornoCnpjValido)
            {
               string SubstringCnpj14 = cnpj.Substring(8, 4);
            
                if (SubstringCnpj14 == "0001")
                {
                    return true;
                }
            
            }

            string SubstringCnpj18 = cnpj.Substring(11, 4);

            if (SubstringCnpj18 == "0001")
            {
                return true;                
            }

            return false;

        }

        public void Inserir(PessoaJuridica pj)
        {

            VerificarPastaArquivo(caminho);

            string[] pjString = {$"{pj.nome},{pj.cnpj},{pj.razaoSocial},{pj.rendimento},{pj.endereco.logradouro},{pj.endereco.numero},{pj.endereco.complemento},{pj.endereco.endComercial}"};

            File.AppendAllLines(caminho, pjString);
        }

        public List<PessoaJuridica> Ler()
        {
            VerificarPastaArquivo(caminho);

            List<PessoaJuridica> ListaPj = new List<PessoaJuridica>();
            
            string[] linhas = File.ReadAllLines(caminho);

            foreach (string cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(",");


                PessoaJuridica cadaPj = new PessoaJuridica();
                Endereco cadaEnd = new Endereco();

                cadaPj.nome = atributos [0];
                cadaPj.cnpj = atributos [1];
                cadaPj.razaoSocial = atributos [2];
                cadaPj.rendimento = float.Parse(atributos [3]);
                cadaEnd.logradouro = atributos[4];
                cadaEnd.numero = int.Parse(atributos[5]);
                cadaEnd.complemento = atributos[6];
                cadaEnd.endComercial = bool.Parse(atributos[7]);
                cadaPj.endereco = cadaEnd;

                ListaPj.Add(cadaPj);
            }


            return ListaPj;
        }

    }
}
