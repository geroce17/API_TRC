using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_TRC.Models.User
{
    public class User
    {
    }

    public class UserResponse
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Lastname { get; set; }
        public string SecondLastname { get; set; }
        public string Email { get; set; }
        public string Birthdate { get; set; }
        public string Phone { get; set; }
    }
}