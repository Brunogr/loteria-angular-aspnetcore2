using System;
using System.Collections.Generic;

namespace Loteria.Application.Model
{
    public class SorteioViewModel
    {
        public int Id { get; set; }
        public int[] Numero { get; set; }
        public DateTime Data { get; set; }
        public List<GanhadorViewModel> Ganhadores { get; set; }
    }
}
