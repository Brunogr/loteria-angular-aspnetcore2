using Loteria.Application.Model;
using Loteria.Application.Service.Interface;
using Loteria.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loteria.WebApi.Controllers
{
    public class CartelaController : BaseController
    {
        ICartelaService _cartelaService;
        public CartelaController(ICartelaService cartelaService)
        {
            _cartelaService = cartelaService;
        }

        [HttpGet]
        public List<CartelaViewModel> GetCartelas()
        {
            var cartelas = _cartelaService.GetAll();

            return cartelas;
        }

        [HttpPost]
        public CartelaViewModel GerarCartela([FromBody]int[] numeros)
        {
            var cartela = _cartelaService.FazerJogo(numeros);

            return cartela;
        }

        [HttpPost("automatica")]
        public CartelaViewModel GerarCartelaAutomatica()
        {
            var cartela = _cartelaService.FazerJogoAutomatico();

            return cartela;
        }
    }
}
