using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bank.MyBank.Models.Enums;

namespace Bank.MyBank.Models
{
  public interface IUser
  {
    string Username { get; set; }
    string Password { get; set; }
    UserEnum UserType { get; set; }
    Guid ID { get; set; }
    void SeeActivity(IUser user, string password, UserEnum type);
    void Validate();
  }
}
