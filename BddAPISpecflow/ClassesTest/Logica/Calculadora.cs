using System;
using System.Collections.Generic;
using System.Text;

namespace BddAPISpecflow.Logica
{
    public class Calculadora
    {
        public int Numero1 { get; set; }
        public int Numero2 { get; set; }

        public int Soma()
        {
            return Numero1 + Numero2;
        }
    }
}
