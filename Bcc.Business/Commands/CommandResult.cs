using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Bcc.Business.Commands
{
    public abstract class CommandBase
    {

    }

    public class CommandResult
    {
        public CommandBase Command { get; }
        public bool Success { get; private set; } = true;
        public string Message { get; private set; } = "";
        public CommandResultError CommandResultError { get; set; }

        public CommandResult(CommandBase command)
        {
            Command = command;
        }

        public void AddMessage(string value)
        {
            if (!string.IsNullOrWhiteSpace(Message))
            {
                Message += Environment.NewLine;
            }
            Message += value;
        }


        public CommandResult Fail(CommandResultError commandResultError, string message)
        {
            Success = false;
            AddMessage(message);
            CommandResultError = commandResultError;
            return this;
        }
    }

    public class CommandResultError
    {
        public static CommandResultError NotFound = new CommandResultError
        {
            HttpCode = HttpStatusCode.NotFound,
            Description = "Not Found"
        };

        public static CommandResultError NotModified = new CommandResultError
        {
            HttpCode = HttpStatusCode.NotModified,
            Description = "Not Modified"
        };

        public static CommandResultError Duplicate = new CommandResultError
        {
            HttpCode = HttpStatusCode.Conflict,
            Description = "Duplicate Record"
        };

        public HttpStatusCode HttpCode { get; set; }
        public string Description { get; set; }
    }
}
