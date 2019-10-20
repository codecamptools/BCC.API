using System.Threading.Tasks;
using Bcc.Business;
using Bcc.Business.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Bcc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : CommandController
    {
        private readonly CommandService _commandService;

        public SessionController(CommandService commandService)
        {
            _commandService = commandService;
        }

        [HttpPost("createSession")]
        public async Task<IActionResult> CreateSession([FromBody]CreateSessionCommand command)
        {
            var result = await HandleCommandAsync(command, _commandService.CreateSession);
            return result;
        }

        [HttpPost("setSessionStatus")]
        public async Task<IActionResult> SetSessionStatus([FromBody]SetSessionStatusCommand command)
        {
            var result = await HandleCommandAsync(command, _commandService.SetSessionStatus);
            return result;
        }
    }
}