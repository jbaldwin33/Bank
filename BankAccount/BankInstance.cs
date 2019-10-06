using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.MyBank.Models;
using Bank.MyBank.ViewModels;

namespace Bank
{
  public class BankInstance
  {
    private static List<IAccount> listOfAccounts = new List<IAccount>();
    public static List<IAccount> ListOfAccounts
    {
      get { return listOfAccounts; }
      set { listOfAccounts = value; }
    }
    private static List<IUser> listOfUsers = new List<IUser>();
    public static List<IUser> ListOfUsers
    {
      get { return listOfUsers; }
      set { listOfUsers = value; }
    }

    public BankInstance() { }

    public BankInstance GetThisBankInstance()
    {
      return this;
    }

    public IUser GetUserByID(Guid id)
    {
      return listOfUsers.Where(x => x.ID == id).FirstOrDefault();
    }

    public IAccount GetAccountByUserID(Guid id)
    {
      return listOfAccounts.Where(x => x.User.ID == id).FirstOrDefault();
    }

    public static void ShowAccountActivity(IUser user)
    {

    }

    public void AddAccount(IAccount account)
    {
      listOfAccounts.Add(account);
    }
    public void AddUser(IUser user)
    {
      listOfUsers.Add(user);
    }
  }
}
