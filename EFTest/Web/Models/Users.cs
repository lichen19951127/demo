using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class Users
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int MyUserId { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
