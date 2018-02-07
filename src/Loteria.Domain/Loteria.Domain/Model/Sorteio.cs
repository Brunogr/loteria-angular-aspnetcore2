using Loteria.Core.Domain;
using Loteria.Core.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loteria.Domain.Model
{
    public class Sorteio : BaseModel
    {
        public Sorteio(int id) : base(id)
        {
            Data = DateTime.Now;
            Numero = Sortear();
            Ganhadores = new List<Ganhador>();
        }

        public int[] Numero { get; private set; }

        public DateTime Data { get; private set; }

        public List<Ganhador> Ganhadores { get; set; }

        private int[] Sortear()
        {
            return GeradorAutomatico.Cartela(1, 60, 6);
        }

        public void AdicionarGanhador(Ganhador ganhador)
        {
            Ganhadores.Add(ganhador);
        }
    }
}
