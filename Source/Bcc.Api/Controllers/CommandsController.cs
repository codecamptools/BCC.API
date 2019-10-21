using System.Threading.Tasks;
using Bcc.Business;
using Bcc.Business.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Bcc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : CommandControllerBase
    {
        private readonly CommandService _commandService;

        public CommandsController(CommandService commandService)
        {
            _commandService = commandService;
        }

        // Conference
        [HttpPost("CreateConference")]
        public async Task<IActionResult> CreateConference([FromBody] CreateConferenceCommand command) =>
            await HandleCommandAsync(command, _commandService.CreateConference);


        // Organization
        [HttpPost("CreateOrganization")]
        public async Task<IActionResult> CreateOrganization([FromBody]CreateOrganizationCommand command) => 
            await HandleCommandAsync(command, _commandService.CreateOrganization);

        [HttpPost("UpdateOrganization")]
        public async Task<IActionResult> UpdateOrganization([FromBody]UpdateOrganizationCommand command) => 
            await HandleCommandAsync(command, _commandService.UpdateOrganization);

        [HttpPost("SetPersonOrganizationRole")]
        public async Task<IActionResult> SetPersonOrganizationRole([FromBody]SetPersonOrganizationRoleCommand command) => 
            await HandleCommandAsync(command, _commandService.SetPersonOrganizationRole);

        [HttpPost("SetSponsorship")]
        public async Task<IActionResult> SetSponsorship([FromBody]SetSponsorshipCommand command) => 
            await HandleCommandAsync(command, _commandService.SetSponsorship);

        // Person
        [HttpPost("UpdatePersonProfile")]
        public async Task<IActionResult> UpdatePersonProfile([FromBody]UpdatePersonProfileCommand command) => 
            await HandleCommandAsync(command, _commandService.UpdatePersonProfile);

        // Session
        [HttpPost("CreateSession")]
        public async Task<IActionResult> CreateSession([FromBody]CreateSessionCommand command) => 
            await HandleCommandAsync(command, _commandService.CreateSession);

        [HttpPost("UpdateSession")]
        public async Task<IActionResult> UpdateSession([FromBody]UpdateSessionCommand command) => 
            await HandleCommandAsync(command, _commandService.CreateSession);

        [HttpPost("SetSessionStatus")]
        public async Task<IActionResult> SetSessionStatus([FromBody]SetSessionStatusCommand command) => 
            await HandleCommandAsync(command, _commandService.SetSessionStatus);

    }
}