using Bank.MyBank;
using Bank.MyBank.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
  public static class Utilities
  {
    public static bool DoCommand(IUser user)
    {
      //Delegate o = new AddCommandDelegate(user);
      SaveToDatabase();
      return true;
    }

    public static bool Login(string username, string password)
    {
      var connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=Bank;Trusted_Connection=True;");
      var query = "SELECT * FROM User WHERE Username=@username";// (ID, FirstName, LastName, AccountID, PasswordHash, PasswordSalt, UserType) VALUES(@ID, @FirstName, @LastName, @AccountID, @PasswordHash, @PasswordSalt, @UserType)";
      var command = new SqlCommand(query, connection);

      bool loginSuccessful = false;
      try
      {
        connection.Open();
        using (SqlDataReader reader = command.ExecuteReader())
        {
          if (reader.Read())
          {
            var hash = reader.GetString(4);
            var salt = reader.GetInt32(5);

            var sec = new SecurePassword(password, salt);
            if (hash == sec.ComputeSaltedHash())
              loginSuccessful = true;
            else
              loginSuccessful = false;
          }
        }
      }
      catch (SqlException sqe)
      {
        loginSuccessful = false;
      }
      finally
      {
        connection.Close();
      }

      return loginSuccessful;
    }

    private static void SaveToDatabase()
    {
      throw new NotImplementedException();
    }

    public static int CreateSalt()
    {
      byte[] saltBytes = new byte[4];
      RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
      rng.GetBytes(saltBytes);

      return (((int)saltBytes[0]) << 24) + (((int)saltBytes[1]) << 16) + (((int)(saltBytes[2]) << 8) + ((int)saltBytes[3]));
    }
  }
}
