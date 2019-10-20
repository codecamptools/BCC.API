using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bcc.Entities;

namespace Bcc.Business.Commands
{
    public interface ICommandList
    {
        // Conference
        CreateConferenceCommand CreateConferenceCommand { get; set; }
        // UpdateConferenceCommand UpdateConferenceCommand { get; set; }

        // Organization
        CreateOrganizationCommand CreateOrganizationCommand { get; set; }
        UpdateOrganizationCommand UpdateOrganizationCommand { get; set; }
        SetPersonOrganizationRoleCommand SetPersonOrganizationRoleCommand { get; set; }
        CreateSponsorshipCommand CreateSponsorshipCommand { get; set; }

        // Person
        UpdatePersonProfileCommand UpdatePersonProfileCommand { get; set; }

        // Session
        CreateSessionCommand CreateSessionCommand { get; set; }
        UpdateSessionCommand UpdateSessionCommand { get; set; }
        SetSessionStatusCommand SetSessionStatusCommand { get; set; }
        // SetSessionScheduleCommand SetSessionScheduleCommand { get; set; }
    }

    public interface ICommandHandlers
    {
        // Conference
        Task<CommandResult<int>> CreateConference(CreateConferenceCommand cmd);
        // CommandResult UpdateConference(UpdateConferenceCommand cmd);

        // Organization
        Task<CommandResult<int>> CreateOrganization(CreateOrganizationCommand cmd);
        Task<CommandResult> UpdateOrganization(UpdateOrganizationCommand cmd);
        Task<CommandResult> SetPersonOrganizationRole(SetPersonOrganizationRoleCommand cmd);
        Task<CommandResult> CreateSponsership(CreateSponsorshipCommand cmd);

        // Person
        Task<CommandResult> UpdatePersonProfile(UpdatePersonProfileCommand cmd);

        // Session
        Task<CommandResult<int>> CreateSession(CreateSessionCommand cmd);
        Task<CommandResult> UpdateSession(UpdateSessionCommand cmd);
        Task<CommandResult> SetSessionStatus(SetSessionStatusCommand cmd);
        //CommandResult ScheduleSession(SetSessionScheduleCommand cmd);
    }
}
