using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Bcc.Entities
{
    public class Session : DbEntity
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string Title { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }
        [MaxLength(5000)]
        public string Overview { get; set; }

        public RequestedTimeFrame RequestedTimeFrame { get; set; }

        public SessionStatus Status { get; set; }
        public int? OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public int SpeakerId { get; set; }
        public Speaker Speaker { get; set; }
        public int ScheduleId { get; set; }
        public ScheduledSession Schedule { get; set; }
        public int ConferenceId { get; set; }
        public Conference Conference { get; set; }
    }

    public enum SessionStatus
    {
        PendingApproval = 0,
        Denied = 1,
        Cancelled = 2,
        Approved = 3,
        Scheduled = 4
    }

    public enum RequestedTimeFrame
    {
        None,
        Morning,
        Afternoon
    }
}

