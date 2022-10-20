using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shoppingweb.BLL;
using System.Data.SqlClient;

namespace Shoppingweb.DAL
{
    public class ProducesDB
    {
        public static void addProduces(Produces produces) {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;
            cmdInsert.CommandText = "INSERT INTO Produces(Title,Price,Num,Image,Information,Date,State)" +
                "VALUES(@Title,@Price,@Num,@Image,@Information,@Date,@State)";
            cmdInsert.Parameters.AddWithValue("@Title", produces.Title);
            cmdInsert.Parameters.AddWithValue("@Price",produces.Price);
            cmdInsert.Parameters.AddWithValue("@Num", produces.Num);
            cmdInsert.Parameters.AddWithValue("@Image", produces.Image);
            cmdInsert.Parameters.AddWithValue("@Information", produces.Information);
            cmdInsert.Parameters.AddWithValue("@Date",produces.Date);
            cmdInsert.Parameters.AddWithValue("@State", produces.State);
            cmdInsert.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }

        public static Produces SearchProduces(int Id) {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchByProduces = new SqlCommand();
            cmdSearchByProduces.Connection = conn;
            cmdSearchByProduces.CommandText = "SELECT * FROM Produces WHERE Id = @Id";
            cmdSearchByProduces.Parameters.AddWithValue("@Id", Id);
            SqlDataReader reader = cmdSearchByProduces.ExecuteReader();
            Produces produces = new Produces();
            if (reader.Read()) {
                produces.Id = Convert.ToInt32(reader["Id"]);
                return produces;
            }
            return null;

        }
    }
}