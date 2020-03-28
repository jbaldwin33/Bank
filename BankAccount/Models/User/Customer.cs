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
  public class Customer : NotifyPropertyChanged, IUser
  {
    public Customer() { }
    public Customer(string username, string password, string firstName, string lastName, UserEnum userType)
    {
      this.username = username;
      this.password = password;
      this.firstName = firstName;
      this.lastName = lastName;
      this.userType = userType;
      this.id = Guid.NewGuid();
    }


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

    private string firstName;
    public string FirstName
    {
      get { return firstName; }
      set { SetProperty(ref firstName, value); }
    }

    private string lastName;
    public string LastName
    {
      get { return lastName; }
      set { SetProperty(ref lastName, value); }
    }

    private UserEnum userType;
    public UserEnum UserType
    {
      get { return userType; }
      set { SetProperty(ref userType, value); }
    }

    private Guid id;
    public Guid ID
    {
      get { return id; }
      set { SetProperty(ref id, value); }
    }

    //private Account account;
    public Account Account { get; set; }


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
  }
}
