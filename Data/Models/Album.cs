﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Album
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int ProducerId { get; set; }

        public Producer Producer { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
