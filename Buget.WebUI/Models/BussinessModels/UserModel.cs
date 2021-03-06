﻿using System;
using System.Collections.Generic;

namespace Buget.WebUI.Models.BussinessModels
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
