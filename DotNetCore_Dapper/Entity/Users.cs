using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
