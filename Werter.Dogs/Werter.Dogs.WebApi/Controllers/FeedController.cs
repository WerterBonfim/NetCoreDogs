using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Werter.Dogs.Servicos.Querys.Interfaces;

namespace Werter.Dogs.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly IFeedQuery _feedQuery;

        public FeedController(IFeedQuery feedQuery)
        {
            _feedQuery = feedQuery;
        }

        [HttpGet]
        public IActionResult ListarFeed()
        {
            var feeds = _feedQuery.ListarFeed();
            return Ok(feeds);
        }
    }
}