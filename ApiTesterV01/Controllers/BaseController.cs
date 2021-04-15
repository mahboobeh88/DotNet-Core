using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace ApiTesterV01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BaseController : ControllerBase
    {

    }
}
