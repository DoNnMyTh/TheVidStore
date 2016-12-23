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
        public int NumberOfMovies { get; set; }
        public int YearOfRelease { get; set; }
        public string GenreOfMovie { get; set; }

    }
}