using Loteria.Application.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loteria.Application.Service.Interface
{
    public interface ISorteioService
    {
        SorteioViewModel GerarSorteio();
    }
}
