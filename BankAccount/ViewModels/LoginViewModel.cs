using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        LoginFailed = true;
      else
        LoginFailed = false;
    }

    public event EventHandler LoginHandler;
    private void DoLogin()
    {
      LoginHandler?.Invoke(this, null);
    }

    public ICommand LoginCommand => new RelayCommand(() => { Login(); });
  }
}
