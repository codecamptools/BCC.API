using System;
using System.Collections.Generic;
using System.Text;

namespace Bcc.Entities
{
    public class Person : DbEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public PersonProfile Profile { get; set; }
    }
}
