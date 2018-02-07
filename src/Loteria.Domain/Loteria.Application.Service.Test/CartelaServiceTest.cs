using Loteria.Application.Model.AutoMapper;
using Loteria.Application.Service.Interface;
using Loteria.Core.Test;
using Loteria.Domain.Model;
using Loteria.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Loteria.Application.Service.Test
{
    public class CartelaServiceTest
    {
        ICartelaService _cartelaService;
        public CartelaServiceTest()
        {
            var cartelaRepository = FakeRepository<Cartela>.GetMock<CartelaRepository>().Object;
            var automapper = AutoMapperConfig.RegisterMappings().CreateMapper();
            _cartelaService = new CartelaService(cartelaRepository, automapper);
        }

        [Fact]
        public void Sucesso_GerarCartela()
        {
            var cartela = _cartelaService.FazerJogo(new int[]{ 5, 10, 15, 20, 30, 40});

            Assert.NotNull(cartela);
        }

        [Fact]
        public void Sucesso_GerarDuasCartelasConferirIdSequencial()
        {
            var cartela = _cartelaService.FazerJogo(new int[] { 5, 10, 15, 20, 30, 40 });

            Assert.NotNull(cartela);

            var cartela2 = _cartelaService.FazerJogoAutomatico();

            Assert.Equal(2, cartela2.Id);
        }
    }
}
