using Loteria.Application.Model.AutoMapper;
using Loteria.Application.Service.Interface;
using Loteria.Core.Test;
using Loteria.Core.Test.FakeData;
using Loteria.Domain.Model;
using Loteria.Infra.Data.Repository;
using System;
using System.Linq;
using Xunit;

namespace Loteria.Application.Service.Test
{
    public class SorteioServiceTest
    {
        ISorteioService _sorteioService;
        public SorteioServiceTest()
        {
            var sorteioRepository = FakeRepository<Sorteio>.GetMock<SorteioRepository>().Object;
            var cartelaRepository = FakeRepository<Cartela>.GetMock<CartelaRepository>(MockDomain.Cartelas(1000000)).Object;

            var automapper = AutoMapperConfig.RegisterMappings().CreateMapper();

            _sorteioService = new SorteioService(sorteioRepository, cartelaRepository, automapper);
        }

        [Fact]
        public void Sucesso_Sorteio()
        {
            var resultadoSorteio = _sorteioService.GerarSorteio();

            Assert.NotNull(resultadoSorteio);
            Assert.Equal(6, resultadoSorteio.Numero.Count());

            Assert.NotEqual(0, resultadoSorteio.Ganhadores.Count());
        }
    }
}
