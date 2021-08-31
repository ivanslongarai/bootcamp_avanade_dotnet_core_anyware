using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGamesCatalog.Exceptions
{
    public class NotExistsGameException : Exception
    {
        public NotExistsGameException() : base("Este jogo já existe cadastrado")
        {
            
        }
    }
}
