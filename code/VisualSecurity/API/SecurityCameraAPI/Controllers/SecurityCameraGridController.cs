using MediatR;
using Microsoft.AspNetCore.Mvc;
using SecurityCameraAPI.Application.Queries;

namespace SecurityCameraAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class SecurityCameraGridController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SecurityCameraGridController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetGridData")]
        public ActionResult Get()
        {
            var results = _mediator.Send(new SecurityGridRequest());

            return Ok(results);
        }
    }
}
