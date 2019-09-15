using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
  public class Customer : User
  {
    private Account account;
    public Account Account { get; set; }

    public Customer(string username, string password, int id) : base(username, password, UserEnum.User, id)
    {
      this.account = new Account();
    }


    public override void Validate()
    {
      throw new NotImplementedException();
    }
  }
}
