using Shoppingweb.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shoppingweb.BLL
{
    public class User
    {
        private int id;
        private string username;
        private string password;
        private string name;
        private string address;
        private int sex;
        private string phonenumber;
        private string email;

        
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Phonenumber { get => phonenumber; set => phonenumber = value; }
        public string Email { get => email; set => email = value; }
        public int Sex { get => sex; set => sex = value; }
        public int Id { get => id; set => id = value; }

        public void SaveUser(User user)
        {
            UserDB.SaveUser(user);
        }
        public void SearchUser(string username)
        {
            UserDB.SearchUser(username);
        }
        public bool IsOnlyUser(string username)
        {
            return UserDB.IsOnlyUser(username);
        }
        public bool IsValidateLogin(string username, string password)
        {
            return UserDB.IsLoginValidate(username, password);
        }
        public User SearchAccountById(int Id)
        {
            return UserDB.SearchAccountById(Id);
        }
        public void UpdateUser(User user) {
            UserDB.UpdateUser(user);
        }
        public void DeleteUser(int Id)
        {
            UserDB.DeleteRecord(Id);
        }
    }
}