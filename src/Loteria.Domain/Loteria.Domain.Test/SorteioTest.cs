using Loteria.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Loteria.Domain.Test
{
    public class SorteioTest
    {
        [Fact]
        public void Sucesso_CriarSorteio()
        {
            var sorteio = new Sorteio(1);


            Assert.Equal(1, sorteio.Id);

            Assert.Equal(DateTime.Now.Date, sorteio.Data.Date);

            Assert.Equal(6, sorteio.Numero.Length);
        }

        [Fact]
        public void Sucesso_ValidarSorteioGerado()
        {
            var sorteio = new Sorteio(1);

            foreach (var numero in sorteio.Numero)
            {
                Assert.Equal(1, sorteio.Numero.Where(n => n == numero).Count());
                Assert.InRange(numero, 1, 60);
            }
           
        }
    }
}
