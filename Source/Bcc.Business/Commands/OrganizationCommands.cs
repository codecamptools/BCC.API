using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Bcc.Business.Helpers;
using Bcc.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Bcc.Business.Commands
{
    public class CreateOrganizationCommand : CommandBase
    {

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public string Image { get; set; }
    }

    public class UpdateOrganizationCommand : CreateOrganizationCommand
    {
        [NonZero]
        public int OrganizationId { get; set; }

        [MaxLength(5000)]
        public string Description { get; set; }
    }

    public class SetPersonOrganizationRoleCommand : CommandBase
    {
        [NonZero]
        public int OrganizationId { get; set; }

        [NonZero]
        public int PersonId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public OrganizationRole Role { get; set; }
    }

    public class SetSponsorshipCommand : CommandBase
    {
        [NonZero]
        public int OrganizationId { get; set; }

        [NonZero]
        public int ConferenceId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public SponsorLevel SponsorLevel { get; set; }
    }
}
