using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Bcc.Entities;
using Newtonsoft.Json;

namespace Bcc.Business.Commands
{
    public abstract class CommandBase
    {
        [JsonIgnore]
        public int CurrentUserId { get; set; }
    }

    public class CommandResult
    {
        public CommandBase Command { get; }
        public bool IsSuccess { get; private set; } = true;
        public string Message { get; private set; } = "";

        public CommandResultError CommandResultError { get; set; }

        protected CommandResult(CommandBase command)
        {
            Command = command;
        }

        public void AddMessage(string value)
        {
            if (!string.IsNullOrWhiteSpace(Message))
            {
                Message += "\n";
            }
            Message += value;
        }

        public static CommandResult Success(CommandBase command, string message = "") =>
            new CommandResult(command)
            {
                IsSuccess = true,
                Message = message,
            };

        public static CommandResult Fail(CommandBase command, CommandResultError commandResultError, string message) =>
            new CommandResult(command)
            {
                IsSuccess = false,
                CommandResultError = commandResultError,
                Message = message,
            };


        public static CommandResult NotFound(CommandBase command, string message) => Fail(command, CommandResultError.NotFound, message);
        public static CommandResult NotModified(CommandBase command, string message) => Fail(command, CommandResultError.NotModified, message);
        public static CommandResult Duplicate(CommandBase command, string message) => Fail(command, CommandResultError.Duplicate, message);

    }
    public class CommandResult<T> : CommandResult
    {
        public CommandBase Command { get; }
        public bool IsSuccess { get; protected set; } = true;
        public string Message { get; protected set; } = "";
        public T Data { get; set; }
        public CommandResultError CommandResultError { get; set; }

        protected CommandResult(CommandBase command) : base(command)
        {
        }

        public static CommandResult<T> Success(CommandBase command, T data, string message = "") =>
            new CommandResult<T>(command)
            {
                IsSuccess = true,
                Data = data,
                Message = message,
            };

        public static CommandResult<T> Fail(CommandBase command, CommandResultError commandResultError, string message) =>
            new CommandResult<T>(command)
            {
                IsSuccess = false,
                CommandResultError = commandResultError,
                Message = message,
            };

        public static CommandResult<T> NotFound(CommandBase command, string message) => Fail(command, CommandResultError.NotFound, message);
        public static CommandResult<T> NotModified(CommandBase command, string message) => Fail(command, CommandResultError.NotModified, message);
        public static CommandResult<T> Duplicate(CommandBase command, string message) => Fail(command, CommandResultError.Duplicate, message);


    }

    public class CommandResultError
    {
        public static readonly CommandResultError NotFound = new CommandResultError
        {
            HttpCode = HttpStatusCode.NotFound,
            Description = "Not Found"
        };

        public static readonly CommandResultError NotModified = new CommandResultError
        {
            HttpCode = HttpStatusCode.NotModified,
            Description = "Not Modified"
        };

        public static readonly CommandResultError Duplicate = new CommandResultError
        {
            HttpCode = HttpStatusCode.Conflict,
            Description = "Duplicate Record"
        };

        public HttpStatusCode HttpCode { get; set; }
        public string Description { get; set; }
    }
}
