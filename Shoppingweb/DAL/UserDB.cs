using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Shoppingweb.BLL;
namespace Shoppingweb.DAL
{
    public class UserDB
    {
        public static void SaveUser(User user)
        {
            //SqlConnection conn = new SqlConnection();
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;
            cmdInsert.CommandText = "INSERT INTO t_user (Username,Password,Email,Name,Address,Sex,Phonenumber)" +
                                    "VALUES(@Username,@Password,@Email,@Name,@Address,@Sex,@Phonenumber)";
            cmdInsert.Parameters.AddWithValue("@Username", user.Username);
            cmdInsert.Parameters.AddWithValue("@Password", user.Password);
            cmdInsert.Parameters.AddWithValue("@Email", user.Email);
            cmdInsert.Parameters.AddWithValue("@Name", user.Name);
            cmdInsert.Parameters.AddWithValue("@Address", user.Address);
            cmdInsert.Parameters.AddWithValue("@Sex", user.Sex);
            cmdInsert.Parameters.AddWithValue("@Phonenumber", user.Phonenumber);
            cmdInsert.Connection = conn;
            cmdInsert.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
        public static User SearchUser(string username) {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchByUsername = new SqlCommand();
            cmdSearchByUsername.Connection = conn;
            cmdSearchByUsername.CommandText = "SELECT * FROM t_user WHERE Username = @Username ";
            cmdSearchByUsername.Parameters.AddWithValue("@Username", username);
            SqlDataReader reader = cmdSearchByUsername.ExecuteReader();
            User user = new User();
            if (reader.Read())
            {
                user.Username = reader["Username"].ToString();
                return user;
            }
            return null;
        }
        public static bool  IsOnlyUser(string username) {
            User user = UserDB.SearchUser(username);
            if (user != null) {
                return true;
            }
            return false;

        }
        public bool IsValidateLogin(string username, string password)
        {
            return UserDB.IsLoginValidate(username, password);
        }
        public static User LoginUser(string username, string password)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchUser = new SqlCommand();
            cmdSearchUser.Connection = conn;
            cmdSearchUser.CommandText = "SELECT * FROM t_user WHERE Username = @Username AND Password = @Password;";
            cmdSearchUser.Parameters.AddWithValue("@Username", username);
            cmdSearchUser.Parameters.AddWithValue("@Password", password);
            SqlDataReader reader = cmdSearchUser.ExecuteReader();
            User user = new User();
            if (reader.Read())
            {
                user.Username = reader["Username"].ToString();
                user.Password = reader["Password"].ToString();
                return user;
            }
            return null;
        }
        public static bool IsLoginValidate(string username, string password)
        {
            User user = UserDB.LoginUser(username, password);
            if (user != null)
            {
                return true;
            }
            return false;
        }
        public static User SearchAccountById(int Id)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchByAccountId = new SqlCommand();
            cmdSearchByAccountId.Connection = conn;
            cmdSearchByAccountId.CommandText = "SELECT * FROM t_user WHERE Id = @Id ";
            cmdSearchByAccountId.Parameters.AddWithValue("@Id", Id);
            SqlDataReader reader = cmdSearchByAccountId.ExecuteReader();
            User user = new User();
            if (reader.Read())
            {
                user.Id = Convert.ToInt32(reader["Id"]);
                return user;
            }
            return null;
        }
        public static void UpdateUser(User user) {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.CommandText = "UPDATE t_user " +
                                    "SET Id = @Id," +
                                    " Password = @Password," +
                                    "Username = @Username," +
                                    "Name = @Name," +
                                    "Address = @Address," +
                                    "Sex = @Sex," +
                                    "Phonenumber = @Phonenumber," +
                                    "Email = @Email," +
                                    "WHERE Username = @Username";
            cmdUpdate.Parameters.AddWithValue("@Id", user.Id);
            cmdUpdate.Parameters.AddWithValue("@Password", user.Password);
            cmdUpdate.Parameters.AddWithValue("@Username", user.Username);
            cmdUpdate.Parameters.AddWithValue("@Name", user.Name); 
            cmdUpdate.Parameters.AddWithValue("@Address", user.Address); 
            cmdUpdate.Parameters.AddWithValue("@Sex", user.Sex); 
            cmdUpdate.Parameters.AddWithValue("@Phonenumber", user.Phonenumber); 
            cmdUpdate.Parameters.AddWithValue("@Email", user.Email); 
            cmdUpdate.Connection = conn;
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
        }
        public static void DeleteRecord(int Id) {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.CommandText = "DELETE FROM t_user " +
                                    "WHERE Id = @Id";
            cmdDelete.Parameters.AddWithValue("@Id", Id);
            cmdDelete.Connection = conn;
            cmdDelete.ExecuteNonQuery();
            conn.Close();
        }
    }
}