using System;
using System.Net;
using System.Threading.Tasks;
using Bcc.Business.Commands;

namespace Bcc.Business
{
    public interface IPersonService
    {
        Task<CommandResult> UpdatePersonProfile(UpdatePersonProfileCommand command);
    }

    public class PersonService : IPersonService
    {
        public async Task<CommandResult> UpdatePersonProfile(UpdatePersonProfileCommand command)
        {
            var commandResult = new CommandResult(command);
            //todo build out the stuff
            return commandResult;
        }
    }
}
