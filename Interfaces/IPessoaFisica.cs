using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgBackEnd.Interfaces
{
    public interface IPessoaFisica
    {
        bool ValidarDataNasc(DateTime dataNasc);
    }
}