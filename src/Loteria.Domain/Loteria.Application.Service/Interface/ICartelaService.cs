using Loteria.Application.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loteria.Application.Service.Interface
{
    public interface ICartelaService
    {
        CartelaViewModel FazerJogo(int[] numeros);
        CartelaViewModel FazerJogoAutomatico();

        List<CartelaViewModel> GetAll();
    }
}
