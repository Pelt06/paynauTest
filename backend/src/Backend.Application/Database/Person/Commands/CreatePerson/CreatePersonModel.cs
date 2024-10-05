﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Database.Person.Commands.CreatePerson
{
    public class CreatePersonModel
    {
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string userName { get; set; } = string.Empty;
        public DateTime birthday { get; set; } = DateTime.Now;
        public string email { get; set; } = string.Empty;
        public string phoneNumber { get; set; } = string.Empty;
    }
}
