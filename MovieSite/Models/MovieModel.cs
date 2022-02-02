using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieSite.Models
{
    public class MovieModel
        //have the same as inputs in form
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        

        [Required (ErrorMessage ="Please enter a movie title")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Please enter a valid year")]
        public int Year { get; set; }
        [Required (ErrorMessage ="Please enter a movie director")]
        public string Director { get; set; }
        [Required(ErrorMessage ="Please enter a movie rating")]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string LentTo { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }

        //Build a foreign key relationship

        [Required]
        public int CategoryId { get; set; }
       
        public Category Category { get; set; }
    }
}
