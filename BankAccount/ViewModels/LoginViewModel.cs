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

    public LoginViewModel()
    {

    }

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
      LoginFailed = true;
      if (ValidateFields())
      {
        try
        {
          Utilities.Login(Username, Password);
          LoginFailed = false;
        }
        catch (NullReferenceException ex) //not found exception
        {
          OnDisplayMessage(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        catch (Exception ex)
        {
          OnDisplayMessage(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        finally
        {
          if (!LoginFailed)
            DoLogin();
        }
      }
    }

    private bool ValidateFields()
    {
      string message = string.Empty;
      if (string.IsNullOrEmpty(Username))
        message = "Username must contain a value.";
      else if (string.IsNullOrEmpty(Password))
        message = "Password must contain a value.";

      if (string.IsNullOrEmpty(message))
        return true;
      else
      {
        OnDisplayMessage(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        return false;
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
