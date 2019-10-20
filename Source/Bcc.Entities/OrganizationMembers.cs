namespace Bcc.Entities
{
    public class OrganizationMembers : DbEntity
    {
        public int OrganizationId { get; set; }
        public int UserId { get; set; }
        public OrganizationRole Role { get; set; }
    }
}