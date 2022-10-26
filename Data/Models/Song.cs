using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Song
    {
        public Song()
        {
            this.SongPerformers = new HashSet<SongPerformer>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int AlbumId { get; set; }

        public Album Album { get; set; }

        public int WriterId { get; set; }

        public Writer Writer { get; set; }

        public ICollection<SongPerformer> SongPerformers { get; set; }
    }
}
