using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
