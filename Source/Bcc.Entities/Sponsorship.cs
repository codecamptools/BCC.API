using System;
using System.Collections.Generic;
using System.Text;

namespace Bcc.Entities
{
    public class Sponsorship : DbEntity
    {
        public int Id { get; set; }
        public Organization Organization { get; set; }
        public SponsorLevel SponsorLevel { get; set; }
        public int ConferenceId { get; set; }
        public Conference Conference { get; set; }
    }
}
