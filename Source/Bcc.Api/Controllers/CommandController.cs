using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bcc.Business.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bcc.Api.Controllers
{
    [Authorize]
    public abstract class CommandController : ControllerBase
    {
        //private readonly IUserService _userService;

        public CommandController()
        {
            //_userService = userService;
        }

        public async Task<IActionResult> HandleCommandAsync<T>(T command, Func<T, Task<CommandResult>> action, int retriesRemaining = 0, int delayMsAfterRetry = 100) where T : CommandBase
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            //command.CurrentUser = await _userService.GetCurrentUserAsync();
            try
            {
                var commandResult = await action(command);
                if (commandResult.Success)
                {
                    return Ok(commandResult);
                }
                return StatusCode((int?)commandResult.CommandResultError?.HttpCode ?? StatusCodes.Status400BadRequest, commandResult.Message);

            }
            catch (Exception ex)
            {
                if (retriesRemaining == 0)
                {
                    throw;
                }

                retriesRemaining -= 1;
                await Task.Delay(delayMsAfterRetry);
                return await HandleCommandAsync(command, action, retriesRemaining);

            }

        }
    }
}
