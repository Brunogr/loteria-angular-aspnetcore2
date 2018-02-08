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
    public class SorteioController : BaseController
    {
        ISorteioService _sorteioService;
        public SorteioController(ISorteioService sorteioService)
        {
            _sorteioService = sorteioService;
        }

        [HttpPost]
        public SorteioViewModel GerarSorteio()
        {
            var sorteio = _sorteioService.GerarSorteio();

            return sorteio;
        }
    }
}
