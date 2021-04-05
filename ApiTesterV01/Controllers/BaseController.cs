using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace ApiTesterV01.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BaseController : ControllerBase
    {
       
    }
}
