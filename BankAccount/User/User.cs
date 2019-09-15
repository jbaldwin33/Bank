using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
  public abstract class User
  {
    private string username;
    public string Username { get; set; }
    private string password;
    public string Password { get; set; }
    private UserEnum userType;
    public UserEnum UserType { get; set; }
    private int id;
    public int ID { get; set; }

    public User(string username, string password, UserEnum userType, int id)
    {
      this.username = username;
      this.password = password;
      this.userType = userType;
      this.id = id;
    }

    public void SeeActivity(User user, string password, UserEnum type)
    {
      if (type == UserEnum.Administrator)
      {
        Utilities.ShowActivity(user);
      }
      else
      {
        if (string.Equals(user.password, password))
        {
          Utilities.ShowActivity(user);
        }
      }
    }
    public abstract void Validate();
  }
}
