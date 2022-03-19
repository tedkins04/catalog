using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    public class Publisher
    {
        [Key, Required]
        public int Id { get; set; }

        [Required, StringLength(128)]
        public string Name { get; set; }
    }
}
