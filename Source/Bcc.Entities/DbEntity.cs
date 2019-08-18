using System;

namespace Bcc.Entities
{
    public class DbEntity
    {
        public DateTimeOffset ModifiedAt { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}