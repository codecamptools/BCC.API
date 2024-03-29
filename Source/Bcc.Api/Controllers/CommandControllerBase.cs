﻿using System;
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
    public abstract class CommandControllerBase : ControllerBase
    {
        //private readonly IUserService _userService;

        protected CommandControllerBase()
        {
            //_userService = userService;
        }

        protected async Task<IActionResult> HandleCommandAsync<T, TK>(T command, Func<T, Task<TK>> action,
            int retriesRemaining = 0, int delayMsAfterRetry = 100) where T : CommandBase where TK : CommandResult
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            //command.CurrentUserId = await _userService.GetCurrentUserAsync();
            command.CurrentUserId = 1;
            try
            {
                var commandResult = await action(command);
                if (commandResult.IsSuccess)
                {
                    return Ok(commandResult);
                }

                return StatusCode((int?)commandResult.CommandResultError?.HttpCode ?? StatusCodes.Status400BadRequest,
                    commandResult.Message);

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
