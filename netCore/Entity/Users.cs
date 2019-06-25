using System;

namespace Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Users
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
