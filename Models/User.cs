using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace AuthManual.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
        public string Email { get; set; }

        public static List<User> GetUsers()
        {
            List<User> users = new List<User>()
            {
                new User { Id = 1, UserName = "NormalUser", Password = "12345", Roles = "User", Email = "user@gmail.com"},
                new User { Id = 2, UserName = "Admin", Password = "12345", Roles = "admin", Email = "admin@gmail.com"},
                new User { Id = 3, UserName = "SuperAdmin", Password = "12345", Roles = "superadmin", Email = "superadmin@gmail.com"},
            };
            return users;
        }
    }
}