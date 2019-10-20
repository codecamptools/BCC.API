using System.Collections.Generic;
using System.Threading.Tasks;
using Bcc.Business;
using Bcc.Business.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Bcc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : CommandController
    {
        private readonly CommandService _commandService;

        public PersonsController(CommandService commandService)
        {
            _commandService = commandService;
        }
        
        [HttpPost("updateProfile")]
        public async Task<IActionResult> UpdateProfile([FromBody]UpdatePersonProfileCommand command)
        {
            var result = await HandleCommandAsync(command, _commandService.UpdatePersonProfile);
            return result;
        }
    }
}
