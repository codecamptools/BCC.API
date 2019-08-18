using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;
using Bcc.Business.Helpers;

namespace Bcc.Business.Commands
{
    public class UpdatePersonProfileCommand : CommandBase
    {
        [NonZero]
        public int PersonId { get; set; }

        [Required(AllowEmptyStrings = false), MaxLength(20)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false), MaxLength(20)]
        public string LastName { get; set; }
        [StringLength(1000)]
        public string Bio { get; set; }

        [Url]
        public string Website { get; set; }

        [Url]
        public string LinkedIn { get; set; }

        [Url]
        public string OtherUrl { get; set; }
    }
}
