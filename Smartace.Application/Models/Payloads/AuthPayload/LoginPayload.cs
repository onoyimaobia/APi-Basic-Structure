using System;
using System.Collections.Generic;
using System.Text;

namespace Smartace.Application.Models.Payloads.AuthPayload
{
    public class LoginPayload
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
