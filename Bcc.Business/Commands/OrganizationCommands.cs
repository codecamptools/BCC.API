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
        public string Image { get; set; } // could do a lot with this, including Azure Functions to give us back the sizes we want
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

}
