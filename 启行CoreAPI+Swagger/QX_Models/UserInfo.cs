﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QX_Models
{
    public class UserInfo
    {
        public int ID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int CID { get; set; }
    }
}
