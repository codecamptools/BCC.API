using System.Collections.Generic;

namespace Bcc.Entities
{
    public class Speaker : DbEntity
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public PersonProfile Profile { get; set; }
        public ICollection<Session> Sessions { get; set; }
    }
}