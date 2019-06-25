using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.net
{
    public class Users:BaseEntity
    {
        public int UsersId { get; set; }

        public string Name { get; set; }

    }
}