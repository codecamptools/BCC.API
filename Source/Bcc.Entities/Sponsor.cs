using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Bcc.Entities
{
    public class Sponsor : DbEntity
    {
        [Key, Column(Order = 0)]
        public int OrganizationId { get; set; }
        [Key, Column(Order = 1)]
        public int ConferenceId { get; set; }
        public Organization Organization { get; set; }
        [Column(TypeName = "nvarchar(24)")]
        public SponsorLevel SponsorLevel { get; set; }
        public Conference Conference { get; set; }
    }
}
