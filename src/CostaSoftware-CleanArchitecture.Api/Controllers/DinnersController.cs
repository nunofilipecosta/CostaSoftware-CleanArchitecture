using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CostaSoftware_CleanArchitecture.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DinnersController : ApiController
{
    [HttpGet]
    public IActionResult ListDinners()
    {
        if(HttpContext.User.Identity.IsAuthenticated)
        {
            return Ok(Array.Empty<string>());
        }
        else
        {
            return Ok(Array.Empty<string>());
        }
    }
}
