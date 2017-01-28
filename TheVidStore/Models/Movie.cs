using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace TheVidStore.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Range(0 , 20)]
        public int NumberOfMovies { get; set; }
        public DateTime? Year { get; set; }
        public string GenreOfMovie { get; set; }
        public byte NumberAvailable { get; set; }

    }
}