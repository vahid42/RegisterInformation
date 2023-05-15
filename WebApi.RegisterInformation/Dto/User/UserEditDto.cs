using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.RegisterInformation.Domain;

namespace WebApi.RegisterInformation.Dto
{
    public class UserEditDto
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Username { get; set; }


    }
}