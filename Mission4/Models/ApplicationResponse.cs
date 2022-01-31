using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class ApplicationResponse
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [Required(ErrorMessage ="You must enter a valid movie title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "You must enter a valid year (yyyy)")]
        public int Year { get; set; }
        [Required(ErrorMessage = "You must enter a valid director name")]
        public string Director { get; set; }
        [Required(ErrorMessage = "You must enter a valid movie rating")]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }


        //Build Foreign Key Relationship
        //[Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
