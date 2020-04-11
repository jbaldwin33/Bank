using Bank.MyBank.Models;
using Bank.UIFramework;
using Bank.UIFramework.ViewViewModel;
using System;
using System.Data.SqlClient;
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
        CreateUser();
        SignUpComplete = true;
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

    private void CreateUser()
    {
      Customer user = new Customer(username, password, firstName, lastName, UserEnum.User);
      Account account = new Account(startingBalance, AccountTypeEnum.Checking);
      user.AccountID = account.ID;
      account.UserID = user.ID;

      //add user to database
      var connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=Bank;Trusted_Connection=True;");
      var query = "INSERT INTO User (ID, FirstName, LastName, AccountID, PasswordHash, PasswordSalt, UserType, Username) VALUES(@ID, @FirstName, @LastName, @AccountID, @PasswordHash, @PasswordSalt, @UserType, @Username)";
      var command = new SqlCommand(query, connection);

      //add parameters to query
      command.Parameters.AddWithValue("@ID", user.ID);
      command.Parameters.AddWithValue("@FirstName", user.FirstName);
      command.Parameters.AddWithValue("@LastName", user.LastName);
      command.Parameters.AddWithValue("@AccountID", user.AccountID);
      command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
      command.Parameters.AddWithValue("@PasswordSalt", user.PasswordSalt);
      command.Parameters.AddWithValue("@UserType", (int)user.UserType);
      command.Parameters.AddWithValue("@Username", user.Username);

      try
      {
        connection.Open();
        command.ExecuteNonQuery();
        MessageBox.Show("User added successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
      }
      catch (SqlException sqe)
      {
        MessageBox.Show($"An error occurred while adding the user: {sqe.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
      }
      finally
      {
        connection.Close();
      }

      //add account to database
      query = "INSERT INTO Account (ID, AccountType, Balance, UserID) VALUES(@ID, @AccountType, @Balance, @UserID)";
      command = new SqlCommand(query, connection);

      //add parameters to query
      command.Parameters.AddWithValue("@ID", account.ID);
      command.Parameters.AddWithValue("@AccountType", (int)account.AccountType);
      command.Parameters.AddWithValue("@Balance", account.Balance);
      command.Parameters.AddWithValue("@UserID", account.UserID);

      try
      {
        connection.Open();
        command.ExecuteNonQuery();
        MessageBox.Show("Account created successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
      }
      catch (SqlException sqe)
      {
        MessageBox.Show($"An error occurred while creating the account: {sqe.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
      }
      finally
      {
        connection.Close();
      }

      //Utilities.DoCommand(user, CommandType.Add);
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
