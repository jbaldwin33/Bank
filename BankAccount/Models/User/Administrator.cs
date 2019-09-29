using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bank.MyBank.Models
{
  public class Administrator : IUser
  {
    private string username;
    public string Username
    {
      get { return username; }
      set
      {
        username = value;
        SetProperty(ref username, value);
      }
    }
    private string password;
    public string Password
    {
      get { return password; }
      set
      {
        password = value;
        SetProperty(ref password, value);
      }
    }

    private UserEnum userType;
    public UserEnum UserType
    {
      get { return userType; }
      set
      {
        userType = value;
        SetProperty(ref userType, value);
      }
    }

    private int id;
    public int ID
    {
      get { return id; }
      set
      {
        id = value;
        SetProperty(ref id, value);
      }
    }

    public Administrator(string username, string password, UserEnum userType, int id)
    {
      this.username = username;
      this.password = password;
      this.userType = userType;
      this.id = id;
    }

    public void SeeActivity(IUser user, string password, UserEnum type)
    {
      //Utilities.ShowActivity(user);
    }

    public void Validate()
    {
      throw new NotImplementedException();
    }

    public bool SetProperty<T>(ref T fieldName, T value, [CallerMemberName] string propertyName = null)
    {
      if (EqualityComparer<T>.Default.Equals(fieldName, value))
      {
        return false;
      }

      fieldName = value;
      RaisePropertyChanged(propertyName);
      return true;
    }

    protected void RaisePropertyChanged(string propertyName)
    {
      PropertyChangedEventHandler handler = PropertyChanged;
      if (handler != null)
      {
        handler(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

  }
}
