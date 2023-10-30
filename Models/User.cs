﻿using System.ComponentModel.DataAnnotations;

namespace apiBodega.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        [Required]
        public string UserMail { get; set; }
        [Required]
        public string UserPassword { get; set; }
        
        public bool IsBlocked { get; set; }

    }
}
