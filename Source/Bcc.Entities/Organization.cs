using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bcc.Entities
{
    public class Organization : DbEntity
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string Image { get; set; } // could do a lot with this, including Azure Functions to give us back the sizes we want
        public SponsorLevel SponsorLevel { get; set; }
        public ICollection<Speaker> Speakers { get; set; }
    }

    public enum SponsorLevel
    {
        None = 0,
        Silver = 1,
        Gold = 2,
        Bronze = 3,
    }

    public enum OrganizationRole
    {
        None,
        Editor,
        Admin
    }
}