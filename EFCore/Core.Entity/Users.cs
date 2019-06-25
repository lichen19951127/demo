using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30), Required]
        public string Account { get; set; }

        [MaxLength(30), Required]
        public string Password { get; set; }
    }
}
