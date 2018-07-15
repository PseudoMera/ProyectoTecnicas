using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login
{
    class Validacion
    {

        public bool validarTexto(string s)
        {
            if (s.Any(char.IsDigit))
                return false;

            return true;
        }

        public bool validarNumeros(string s)
        {
            if (s.Any(x => char.IsLetter(x)))
                return false;

            return true;
        }
    }
}
