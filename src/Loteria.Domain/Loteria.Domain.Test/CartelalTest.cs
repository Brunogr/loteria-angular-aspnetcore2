using Loteria.Domain.Model;
using System;
using System.Linq;
using Xunit;

namespace Loteria.Domain.Test
{
    public class CartelalTest
    {
        public CartelalTest()
        {

        }
        [Fact]
        public void Sucesso_CriarCartela()
        {
            var cartela = new Cartela(1, new int[6] { 1, 5, 7, 10, 55, 22 });

            Assert.Equal(1, cartela.Id);

            Assert.Equal(DateTime.Now.Date, cartela.Data.Date);

            Assert.Equal(6, cartela.Numero.Length);
        }

        [Fact]
        public void Sucesso_CriarCartelaAutomatica()
        {
            var cartela = new Cartela(1);

            Assert.Equal(1, cartela.Id);

            Assert.Equal(DateTime.Now.Date, cartela.Data.Date);

            Assert.Equal(6, cartela.Numero.Length);
        }

        [Fact]
        public void Sucesso_ValidarNumerosGeradosAutomaticamente()
        {
            var cartela = new Cartela(1);

            foreach (var numero in cartela.Numero)
            {
                Assert.InRange(numero, 1, 60);
            }
        }

        [Fact]
        public void Sucesso_ValidarNumerosIguais()
        {
            var cartela = new Cartela(1);

            foreach (var numero in cartela.Numero)
            {
                Assert.Equal(1, cartela.Numero.Where(n => n == numero).Count());
                Assert.InRange(numero, 1, 60);
            }
        }
    }
}
