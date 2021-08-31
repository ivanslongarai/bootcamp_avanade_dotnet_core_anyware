using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGamesCatalog.Exceptions
{
    public class AlreadyExistsGameException : Exception
    {
        public AlreadyExistsGameException(): base("Este jogo já está cadastrado")
        {

        }
    }
}
