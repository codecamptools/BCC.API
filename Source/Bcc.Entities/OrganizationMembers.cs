using System.ComponentModel.DataAnnotations.Schema;

namespace Bcc.Entities
{
    public class OrganizationMembers : DbEntity
    {
        public int OrganizationId { get; set; }
        public int UserId { get; set; }
        [Column(TypeName = "nvarchar(24)")]
        public OrganizationRole Role { get; set; }
    }
}