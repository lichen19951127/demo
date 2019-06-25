using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace D2D
{
    public class UserInfo
    {
        [Key]
        public string ContextID { get; set; }
        public string Name { get; set; }
    }
}