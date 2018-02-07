using System;
using System.Collections.Generic;
using System.Text;

namespace Loteria.Application.Model
{
    public class CartelaViewModel
    {
        public int Id { get; set; }
        public int[] Numero { get; set; }
        public DateTime Data { get; set; }
    }
}
