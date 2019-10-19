using Bank.MyBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Bank.MyBank.ViewModels
{
  public class SignUpViewModel : BaseViewModel
  {
    private string firstName;
    private string lastName;
    private string username;
    private string password;
    private double startingBalance;
    private bool signUpComplete;
    private bool loginFailed;

    public SignUpViewModel()
    {
      
    }

    public string Firstname
    {
      get { return firstName; }
      set { SetProperty(ref firstName, value); }
    }

    public string Lastname
    {
      get { return lastName; }
      set { SetProperty(ref lastName, value); }
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

    public double StartingBalance
    {
      get { return startingBalance; }
      set { SetProperty(ref startingBalance, value); }
    }

    public bool SignUpComplete
    {
      get { return signUpComplete; }
      set { SetProperty(ref signUpComplete, value); }
    }

    public bool LoginFailed
    {
      get { return loginFailed; }
      set { SetProperty(ref loginFailed, value); }
    }


    private void SignUp()
    {
      SignUpComplete = false;
      if (ValidateFields())
      {
        CreateUser();
        SignUpComplete = true;
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
            DoSignUp();
        }
      }
      else
        SignUpComplete = false;
    }

    private void CreateUser()
    {
      Customer user = new Customer()
      {
        FirstName = firstName,
        LastName = lastName,
        Username = username,
        Password = password,
        UserType = UserEnum.User,
        ID = Guid.NewGuid()
      };
      Account account = new Account()
      {
        Balance = startingBalance,
        User = user
      };
      user.Account = account;

      Utilities.DoCommand(user, CommandType.Add);
    }

    private bool ValidateFields()
    {
      string message = string.Empty;
      if (string.IsNullOrEmpty(Firstname))
        message = "First name must contain a value.";
      else if (string.IsNullOrEmpty(Lastname))
        message = "Last name must contain a value.";
      else if (string.IsNullOrEmpty(Username))
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

    public event EventHandler SignUpHandler;
    private void DoSignUp()
    {
      var eventDelegate = SignUpHandler;
      eventDelegate?.Invoke(this, null);
    }

    public ICommand SignUpCommand => new RelayCommand(() => { SignUp(); });
  }
}
