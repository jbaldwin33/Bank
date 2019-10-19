using Bank.MyBank;
using Bank.MyBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
  public static class Utilities
  {
    public static bool DoCommand(IUser user, CommandType type)
    {
      SaveToDatabase();
      return true;
    }

    public static void Login(string username, string password)
    {
      //if user exists
      //login
      //else if
      //throw null reference exception (change this) user not found 
      //else
      //throw exception
    }

    private static void SaveToDatabase()
    {
      throw new NotImplementedException();
    }
  }

  public enum CommandType
  {
    Add,
    Edit,
    Delete
  }
}
