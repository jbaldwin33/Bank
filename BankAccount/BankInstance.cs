using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
  public class BankInstance
  {
    private static List<Account> listOfAccounts;
    public static List<Account> ListOfAccounts { get; }
    private static List<User> listOfUsers;
    public static List<User> ListOfUsers { get; }

    public BankInstance() { }

    public BankInstance GetThisBankInstance()
    {
      return this;
    }

    public User GetUserByID(int id)
    {
      return listOfUsers.Where(x => x.ID == id).FirstOrDefault();
    }

    public Account GetAccountByUserID(int id)
    {
      return listOfAccounts.Where(x => x.User.ID == id).FirstOrDefault();
    }

    public static void ShowAccountActivity(User user)
    {

    }
  }
}
