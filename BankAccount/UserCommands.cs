using Bank.MyBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.MyBank
{
  public class UserCommands
  {
    public bool AddUserCommand(IUser user)
    {

      return true;
    }

    public bool EditUserCommand(IUser user)
    {

      return true;
    }

    public bool DeleteUserCommand(IUser user)
    {

      return true;
    }


    public delegate bool UserCommandDelegate(IUser user);

  }
}
