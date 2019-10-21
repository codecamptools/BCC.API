using System;
using System.Collections.Generic;
using System.Text;

namespace Bcc.Entities
{
    public class Conference : DbEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<Session> Sessions { get; set; }
        public List<ScheduledSession> ScheduledSessions { get; set; }
        public List<Sponsor> Sponsors { get; set; }
    }
}
