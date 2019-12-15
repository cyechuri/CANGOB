using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMvcLoginiApp.Models
{
    public class LoginModel
    {
        public LoginModel()
        {
            UserName = "";
            Password = "";
        }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}