using System.ComponentModel.DataAnnotations;

namespace Bcc.Entities
{
    public class PersonProfile : DbEntity
    {
        public int Id { get; set; }
        public Person Person { get; set; }

        [MaxLength(30)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string LastName { get; set; }
        [MaxLength(1000)]
        public string Bio { get; set; }
        [MaxLength(100)]
        public string Website { get; set; }
        [MaxLength(100)]
        public string LinkedIn { get; set; }
        [MaxLength(100)]
        public string OtherUrl { get; set; }
    }
}