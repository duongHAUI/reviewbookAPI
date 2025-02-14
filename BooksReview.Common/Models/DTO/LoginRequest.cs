﻿using BooksReview.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.Common.Models.DTO
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public EnumRole RoleType { get; set; }
        public bool Remember { get; set; }
    }
}
