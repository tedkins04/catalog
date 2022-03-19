using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    public class Book
    {
        [Key, Required]
        public int Id { get; set; }

        [Required, StringLength(128)]
        public string Title { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public int PublisherId { get; set; }

        [Required]
        public int Pages { get; set; }

        [Required]
        public int PublicationYear { get; set; }

        [Required, StringLength(128)]
        public string CategoryIds { get; set; }

        [Required]
        public decimal Price { get; set; }

        //public byte[] Photo { get; set; }
    }
}
