using Bank.MyBank.Models;
using Bank.UIFramework;
using Bank.UIFramework.Database;
using Bank.UIFramework.ViewViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using static Bank.MyBank.Models.Enums;

namespace Bank.MyBank.ViewModels
{
  public class SignUpViewModel : BaseViewModel
  {
    private string firstName;
    private string lastName;
    private string username;
    private string password;
    private float startingBalance;
    private bool signUpComplete;
    private bool loginSuccessful;
    private RelayCommand signUpCommand;

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
      get => password;
      set => SetProperty(ref password, value);
    }

    public float StartingBalance
    {
      get { return startingBalance; }
      set { SetProperty(ref startingBalance, value); }
    }

    public bool SignUpComplete
    {
      get { return signUpComplete; }
      set { SetProperty(ref signUpComplete, value); }
    }

    public bool LoginSuccessful
    {
      get { return loginSuccessful; }
      set { SetProperty(ref loginSuccessful, value); }
    }


    private void SignUp()
    {
      SignUpComplete = false;
      if (ValidateFields())
      {
        var successful = CreateUserAndAddToDatabase();
        SignUpComplete = true;
        if (!successful)
          return;

        try
        {
          LoginSuccessful = Utilities.Login(Username, Password);
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
          if (LoginSuccessful)
            DoSignUp();
        }
      }
      else
        SignUpComplete = false;
    }

    private bool CreateUserAndAddToDatabase()
    {
      Customer user = new Customer(username, password, firstName, lastName, UserEnum.User);
      Account account = new Account(startingBalance, AccountTypeEnum.Checking);
      user.AccountID = account.ID;
      account.UserID = user.ID;

      var userKvps = new List<KeyValuePair<string, string>>
      {
        new KeyValuePair<string, string>("ID", user.ID.ToString()),
        new KeyValuePair<string, string>("FIRSTNAME", user.FirstName),
        new KeyValuePair<string, string>("LASTNAME", user.LastName),
        new KeyValuePair<string, string>("ACCOUNTID", user.AccountID.ToString()),
        new KeyValuePair<string, string>("PASSWORDHASH", user.PasswordHash),
        new KeyValuePair<string, string>("PASSWORDSALT", user.PasswordSalt.ToString()),
        new KeyValuePair<string, string>("USERTYPE", ((int)user.UserType).ToString()),
        new KeyValuePair<string, string>("USERNAME", user.Username),
      };

      //this should be server call
      var userAddResponse = DatabaseMethods.AddRowToDatabase("USER", userKvps);
      
      if (userAddResponse.Errors.Length > 0)
        MessageBox.Show($"An error occurred while creating the user: {BuildErrorString(userAddResponse.Errors)}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
      else
        MessageBox.Show("User added successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

      var accountKvps = new List<KeyValuePair<string, string>>
      {
        new KeyValuePair<string, string>("ID", account.ID.ToString()),
        new KeyValuePair<string, string>("ACCOUNTTYPE", ((int)account.AccountType).ToString()),
        new KeyValuePair<string, string>("BALANCE", account.Balance.ToString()),
        new KeyValuePair<string, string>("USERID", account.UserID.ToString())
      };

      var accountAddResponse = DatabaseMethods.AddRowToDatabase("ACCOUNT", accountKvps);

      if (accountAddResponse.Errors.Length > 0)
        MessageBox.Show($"An error occurred while creating the account: {BuildErrorString(accountAddResponse.Errors)}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
      else
        MessageBox.Show("Account created successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

      return userAddResponse.Successful && accountAddResponse.Successful;
    }

    private string BuildErrorString(string[] errors)
    {
      var stringBuilder = new StringBuilder();
      foreach (var error in errors)
        stringBuilder.Append($"{error} {Environment.NewLine}");

      return stringBuilder.ToString();
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

    public RelayCommand SignUpCommand => signUpCommand ?? (signUpCommand = new RelayCommand(SignUp));
  }
}
