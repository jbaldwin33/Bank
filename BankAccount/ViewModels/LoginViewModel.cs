using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Bank.MyBank.ViewModels
{
  public class LoginViewModel : BaseViewModel
  {
    private string username;
    private string password;
    private bool loginFailed;

    public string Username
    {
      get { return username; }
      set { SetProperty(ref username, value); }
    }
    
    public string Password
    {
      get { return password; }
      set { SetProperty(ref password, value); }
    }
    
    public bool LoginFailed
    {
      get { return loginFailed; }
      set { SetProperty(ref loginFailed, value); }
    }

    private void Login()
    {
      if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
      {
        LoginFailed = false;
        DoLogin();
      }
      else
      {
        LoginFailed = true;
        string property = string.IsNullOrEmpty(Username) ? "Username" : "Password";
        OnDisplayMessage($"{property} cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
      }
    }


    public event EventHandler LoginHandler;
    private void DoLogin()
    {
      var eventDelegate = LoginHandler;
      eventDelegate?.Invoke(this, null);
    }

    public ICommand LoginCommand => new RelayCommand(() => { Login(); });
  }
}
