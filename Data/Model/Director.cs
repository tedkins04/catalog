using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    public class Director
    {
        [Key, Required]
        public int Id { get; set; }

        [Required, StringLength(128)]
        public string FirstName { get; set; }

        [Required, StringLength(128)]
        public string LastName { get; set; }
    }
}
