﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetins.WebApi.Models.Peoples.Responses
{
    public class PeoplesResponseModel
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }  

        public string AvatarPath { get; set; }

        public string LoginUrl { get; set; }
    }
}
