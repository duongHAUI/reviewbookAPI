﻿using BooksReview.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BooksReview.Common.Models
{
    public class User : BaseModel
    {
        [Key]
        public Guid user_id { get; set; }
        public string user_name { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public string profile_picture { get; set; } = "https://scontent-hkg1-1.xx.fbcdn.net/v/t1.30497-1/453178253_471506465671661_2781666950760530985_n.png?stp=dst-png_s100x100&_nc_cat=1&ccb=1-7&_nc_sid=136b72&_nc_eui2=AeGpZ9xP7vfQEtNZSmy-med5Wt9TLzuBU1Ba31MvO4FTUCaAK06xG209jvqjoHJFwnZj8grqxZ_SdcE6Q2mhK5Fw&_nc_ohc=PBlN3lEt5FwQ7kNvgFWbu1K&_nc_ht=scontent-hkg1-1.xx&_nc_gid=ARzhuy2jx52s2mqe-HbGdJ_&oh=00_AYAWbc_jVNmi2wD7fkjee5pZ_-w6S0Q2qAFV7c8DOXqq2Q&oe=670E65FA";
        public string social_login_provider { get; set; }
        public string bio { get; set; }
    }
}
