using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mjos.Clean.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
       
    }
}
