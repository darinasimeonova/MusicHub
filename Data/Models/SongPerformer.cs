using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class SongPerformer
    {
        public int SongId { get; set; }

        [Required]
        public Song Songs { get; set; }

        public int PerformerId { get; set; }

        [Required]
        public Performer Performer { get; set; }
    }  
}
