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
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpPost("comment")]
        public async Task<IActionResult> WriteMemo([FromBody]UpdatePersonProfileCommand command)
        {
            var result = await HandleCommandAsync(command, _personService.UpdatePersonProfile);
            return result;
        }
    }
}
