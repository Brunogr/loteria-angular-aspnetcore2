using Loteria.Core.Domain;
using Loteria.Core.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loteria.Domain.Model
{
    public class Cartela : BaseModel
    {
        public Cartela(int id, int[] numero) : base(id)
        {
            Numero = numero;
            Data = DateTime.Now;
        }

        public Cartela(int id) : base(id)
        {
            GerarJogoAutomatico();
            Data = DateTime.Now;
        }

        public int[] Numero { get; private set; }

        public DateTime Data { get; private set; }

        public void GerarJogoAutomatico()
        {
            //Deixei HardCoded, mas a ideia é que seja possível gerar os números como quiser, baseado no jogo.
            Numero = GeradorAutomatico.Cartela(1, 60, 6);
        }
    }
}
