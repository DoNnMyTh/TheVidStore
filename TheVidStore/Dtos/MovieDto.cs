using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TheVidStore.Models;

namespace TheVidStore.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Range(0, 20)]
        public int NumberOfMovies { get; set; }
        public DateTime? Year { get; set; }
        public string GenreOfMovie { get; set; }
    }
}