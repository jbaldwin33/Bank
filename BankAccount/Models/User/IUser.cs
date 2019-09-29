using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.MyBank.Models
{
  public interface IUser : IBasePropertyChanged
  {
    string Username { get; set; }
    string Password { get; set; }
    UserEnum UserType { get; set; }
    int ID { get; set; }
    void SeeActivity(IUser user, string password, UserEnum type);
    void Validate();
  }
}
