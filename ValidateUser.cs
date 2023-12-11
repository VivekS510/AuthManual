using System;
using AuthManual.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthManual
{
    public class ValidateUser
    {
        public static bool Login(string username, string password)
        {
            return User.GetUsers().Any(user => user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Password == password);

        }

        public static User GetUserDetails(string username, string password)
        {
            return User.GetUsers().FirstOrDefault(user => user.UserName.Equals(username) && user.Password == password);

        }
    }
}