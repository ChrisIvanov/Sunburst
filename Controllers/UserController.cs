namespace Sunburst.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("isAuthenticated")]
        [Authorize]
        public IActionResult IsAuthenticated()
        {
            return Ok();
        }
    }
}
