using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
  public class Administrator : User
  {
    public Administrator(string username, string password, int id) : base(username, password, UserEnum.Administrator, id) { }


    public override void Validate()
    {
      throw new NotImplementedException();
    }
  }
}
