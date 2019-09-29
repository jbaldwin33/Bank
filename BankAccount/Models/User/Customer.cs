using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bank.MyBank.Models
{
  public class Customer : IUser
  {
    private string username;
    public string Username
    {
      get { return username; }
      set
      {
        username = value;
        RaisePropertyChanged("Username");
      }
    }
    private string password;
    public string Password
    {
      get { return password; }
      set
      {
        password = value;
        RaisePropertyChanged("Password");
      }
    }

    private UserEnum userType;
    public UserEnum UserType
    {
      get { return userType; }
      set
      {
        userType = value;
        RaisePropertyChanged("UserType");
      }
    }

    private int id;
    public int ID
    {
      get { return id; }
      set
      {
        id = value;
        RaisePropertyChanged("ID");
      }
    }

    private Account account;
    public Account Account { get; set; }

    public Customer(string username, string password, int id, UserEnum userType)
    {
      this.username = username;
      this.password = password;
      this.userType = userType;
      this.id = id;
    }

    public void SeeActivity(IUser user, string password, UserEnum type)
    {
      if (string.Equals(user.Password, password))
      {
        //Utilities.ShowActivity(user);
      }
    }
    public void Validate()
    {

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
