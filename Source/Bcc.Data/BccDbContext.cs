using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Bcc.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bcc.Data
{
    public class BccDbContext : DbContext
    {
        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationMembers> OrganizationMembers { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<ScheduledSession> ScheduledSession { get; set; }
        public DbSet<Sponsor> Sponsor { get; set; }
        public DbSet<PersonProfile> PersonProfiles { get; set; }

        public async Task<Conference> GetActiveConference()
        {
            return await Conferences.Where(x => x.Date >= DateTime.Today).OrderBy(x => x.Date).FirstOrDefaultAsync();
        }
    }
}
