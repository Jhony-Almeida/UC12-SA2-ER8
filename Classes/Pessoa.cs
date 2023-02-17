using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgBackEnd.Interfaces;

namespace ProgBackEnd.Classes
{
    public abstract class Pessoa : IPessoa
    {
        public string? nome {get; set;}

        public float rendimento {get; set;}

        public Endereco? endereco {get; set;}
        

        public abstract float CalcularImposto (float rendimento);

        public void VerificarPastaArquivo(string caminho)
        {
            string pasta = caminho.Split("/")[0];

            if(!Directory.Exists(pasta)){
                Directory.CreateDirectory(pasta);
            }

            if (!File.Exists(caminho))
            {
                using (File.Create(caminho))
                {
                    
                }   
            }
            
                
            



        }

    }
}