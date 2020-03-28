using Bank.UIFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bank.MyBank.Models
{
  public class Administrator : NotifyPropertyChanged, IUser
  {
    private string username;
    public string Username
    {
      get { return username; }
      set
      {
        SetProperty(ref username, value);
      }
    }
    private string password;
    public string Password
    {
      get { return password; }
      set
      {
        SetProperty(ref password, value);
      }
    }

    private UserEnum userType;
    public UserEnum UserType
    {
      get { return userType; }
      set
      {
        SetProperty(ref userType, value);
      }
    }

    private Guid id;
    public Guid ID
    {
      get { return id; }
      set
      {
        SetProperty(ref id, value);
      }
    }

    public Administrator(string username, string password, UserEnum userType)
    {
      this.username = username;
      this.password = password;
      this.userType = userType;
      this.id = Guid.NewGuid();
    }

    public void SeeActivity(IUser user, string password, UserEnum type)
    {
      //Utilities.ShowActivity(user);
    }

    public void Validate()
    {
      throw new NotImplementedException();
    }
  }
}
