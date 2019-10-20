using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Bcc.Business.Helpers;
using Bcc.Entities;

namespace Bcc.Business.Commands
{
    public class CreateSessionCommand : CommandBase
    {
        public string Title { get; set; }

        [Required, MaxLength(150)]
        public string Description { get; set; }

        [Required, MaxLength(5000)]
        public string Overview { get; set; }

        public RequestedTimeFrame RequestedTimeFrame { get; set; }

        public int? OrganizationId { get; set; }

    }

    public class UpdateSessionCommand : CreateSessionCommand
    {
        [NonZero]
        public int SessionId { get; set; }
    }

    public class SetSessionStatusCommand : CommandBase
    {
        [NonZero]
        public int SessionId { get; set; }
        public SessionStatus SessionStatus { get; set; }
    }
}
