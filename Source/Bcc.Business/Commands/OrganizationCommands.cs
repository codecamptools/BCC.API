using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Bcc.Business.Helpers;
using Bcc.Entities;

namespace Bcc.Business.Commands
{
    public class CreateOrganizationCommand
    {

        [Required, MaxLength(50)]
        public string Name { get; set; }
        public string Image { get; set; }
    }

    public class UpdateOrganizationCommand : CreateOrganizationCommand
    {
        [NonZero]
        public int OrganizationId { get; set; }
    }

    public class SetPersonOrganizationRoleCommand
    {
        [NonZero]
        public int OrganizationId { get; set; }
        [NonZero]
        public int PersonId { get; set; }
        public OrganizationRole Role { get; set; }
    }

    public class CreateSponsorshipCommand
    {
        public int OrganizationId { get; set; }
        public SponsorLevel SponsorLevel { get; set; }
        public int ConferenceId { get; set; }
    }
}
