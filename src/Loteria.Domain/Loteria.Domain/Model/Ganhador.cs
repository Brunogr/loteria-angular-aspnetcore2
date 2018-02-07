using System;
using System.Collections.Generic;
using System.Text;

namespace Loteria.Domain.Model
{
    public class Ganhador
    {
        public Ganhador(Cartela cartela, int acertos)
        {
            Acertos = acertos;
            Cartela = cartela;
        }

        public int Acertos { get; private set; }
        public Cartela Cartela { get; private set; }
    }
}
