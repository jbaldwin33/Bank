using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bank.MyBank.ViewModels
{
  public class AccountDetailsViewModel : BaseViewModel
  {
    public AccountDetailsViewModel()
    {
      FirstName = "Josh";
    }

    private string username;
    public string Username
    {
      get { return username; }
      set { SetProperty(ref username, value); }
    }

    private int balance;
    public int Balance
    {
      get { return balance; }
      set { SetProperty(ref balance, value); }
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

    public bool SaveChanges()
    {

      return true;
    }

    public ICommand SaveCommand => new RelayCommand(() => { SaveChanges(); });
  }
}
