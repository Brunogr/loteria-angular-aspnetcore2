using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loteria.WebApi.Controllers.Base
{
    [Produces("application/json")]
    [Route("loteria/api/v1/[controller]")]
    public class BaseController : Controller
    {
    }
}
