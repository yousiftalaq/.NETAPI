using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApi.Models
{
    public class Song
    {
        public int Id { set; get; }
        [Required]
        public string Title { set; get; }
        [Required]
        public string Language { get; set; }
        [Required]
        public string Duration { get; set; }

       // [NotMapped]
      //  public IFormFile Image { get; set; }

      //  public string ImageUrl { get; set; }
    }
}
