using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceAssignment.entity
{
    public class Users
    {
        private int UserId { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        private string Role { get; set; }

        public Users() { }
        public int GetUserId()
        {
            return UserId;
        }

        public string GetUsername()
        {
            return Username;
        }

        public string GetPassword()
        {
            return Password;
        }

        public string GetRole()
        {
            return Role;
        }
        public Users(int userId, string username, string password, string role)
        {
            UserId = userId;
            Username = username;
            Password = password;
            Role = role;
        }

        public override string ToString()
        {
            return $"User{{UserId={UserId}, Username='{Username}', Password='{Password}', Role='{Role}'}}";
        }
    }
}
