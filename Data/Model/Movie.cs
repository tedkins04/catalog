using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Movie
    {
        [Key, Required]
        public int Id { get; set; }

        [Required, StringLength(128)]
        public string Title { get; set; }

        [Required]
        public int DirectorId { get; set; }

        [Required]
        public int PublicationYear { get; set; }

        [Required, StringLength(128)]
        public string ActorIds { get; set; }

        [Required, StringLength(128)]
        public string CategoryIds { get; set; }
    }
}
