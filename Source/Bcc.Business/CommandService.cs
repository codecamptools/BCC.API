using System;
using System.Linq;
using System.Threading.Tasks;
using Bcc.Business.Commands;
using Bcc.Data;
using Bcc.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bcc.Business
{
    public class CommandService : ICommandHandlers
    {
        private readonly BccDbContext _db;

        public CommandService(BccDbContext db)
        {
            _db = db;
        }

        public async Task<CommandResult<int>> CreateConference(CreateConferenceCommand cmd)
        {
            var conferences = await _db.Conferences.ToListAsync();
            if (conferences.Any(x => x.Date.Year == cmd.Date.Year))
            {
                return CommandResult<int>.Duplicate(cmd, $"Conference already exists for year {cmd.Date.Year}");
            }

            var conference = new Conference
            {
                Name = cmd.Name,
                Date = cmd.Date,
            };
            var entity = _db.Conferences.Add(conference);
            await _db.SaveChangesAsync();
            return CommandResult<int>.Success(cmd, entity.Entity.Id);
        }

        public Task<CommandResult<int>> CreateOrganization(CreateOrganizationCommand cmd)
        {
            throw new NotImplementedException();
        }

        public async Task<CommandResult> UpdateOrganization(UpdateOrganizationCommand cmd)
        {
            var org = await _db.Organizations.FindAsync(cmd.OrganizationId);
            if (org == null) { return CommandResult.NotFound(cmd, "Organization Not Found"); }

            org.Name = cmd.Name;
            org.Image = cmd.Image;
            org.Description = cmd.Description;
            await _db.SaveChangesAsync();
            return CommandResult.Success(cmd);
        }

        public Task<CommandResult> SetPersonOrganizationRole(SetPersonOrganizationRoleCommand cmd)
        {
            throw new NotImplementedException();
        }

        public async Task<CommandResult> CreateSponsership(CreateSponsorshipCommand cmd)
        {
            // todo auth
            var sponsorship = await _db.Sponsor.FirstOrDefaultAsync(x => x.ConferenceId == cmd.ConferenceId && x.OrganizationId == cmd.OrganizationId);
            if (sponsorship == null)
            {
                sponsorship = new Sponsor
                {
                    ConferenceId = cmd.ConferenceId,
                    OrganizationId = cmd.OrganizationId
                };
                _db.Add(sponsorship);
            }

            sponsorship.SponsorLevel = cmd.SponsorLevel;
            await _db.SaveChangesAsync();
            return CommandResult.Success(cmd);
        }

        public async Task<CommandResult> UpdatePersonProfile(UpdatePersonProfileCommand cmd)
        {
            var profile = await _db.PersonProfiles.FindAsync(cmd.CurrentUserId);
            if (profile == null)
            {
                profile = new PersonProfile
                {
                    Id = cmd.CurrentUserId
                };
                _db.Add(profile);
            }

            profile.Bio = cmd.Bio;
            profile.FirstName = cmd.FirstName;
            profile.LastName = cmd.LastName;
            profile.LinkedIn = cmd.LinkedIn;
            profile.OtherUrl = cmd.OtherUrl;
            profile.Website = cmd.Website;
            await _db.SaveChangesAsync();
            return CommandResult.Success(cmd);
        }

        public async Task<CommandResult<int>> CreateSession(CreateSessionCommand cmd)
        {
            var conferenceId = _db.GetActiveConference().Id;
            var currentUserId = cmd.CurrentUserId;

            var session = new Session()
            {
                ConferenceId = conferenceId,
                Description = cmd.Description,
                OrganizationId = cmd.OrganizationId,
                Overview = cmd.Overview,
                RequestedTimeFrame = cmd.RequestedTimeFrame,
                SpeakerId = currentUserId
            };

            var entity = _db.Sessions.Add(session).Entity;
            await _db.SaveChangesAsync();
            return CommandResult<int>.Success(cmd, entity.Id);
        }

        public async Task<CommandResult> UpdateSession(UpdateSessionCommand cmd)
        {
            var session = await _db.Sessions.FindAsync(cmd.SessionId);
            if (session == null)
            {
                return CommandResult.NotFound(cmd, "Session not found.");
            }

            session.Description = cmd.Description;
            session.OrganizationId = cmd.OrganizationId;
            session.Overview = cmd.Overview;
            session.RequestedTimeFrame = cmd.RequestedTimeFrame;
            session.Title = cmd.Title;

            await _db.SaveChangesAsync();
            return CommandResult.Success(cmd);
        }

        public async Task<CommandResult> SetSessionStatus(SetSessionStatusCommand cmd)
        {
            var session = await _db.Sessions.FindAsync(cmd.SessionId);
            if (session == null)
            {
                return CommandResult.NotFound(cmd, "Session not found.");
            }

            session.Status = cmd.SessionStatus;
            await _db.SaveChangesAsync();
            return CommandResult.Success(cmd);
        }
    }
}
