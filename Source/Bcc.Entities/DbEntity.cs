using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bcc.Entities
{
    public class DbEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset ModifiedAt { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTimeOffset CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}