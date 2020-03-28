using Bank.UIFramework;
using Bank.UIFramework.ViewViewModel;
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

    private bool nextOk;
    public bool NextOk
    {
      get { return nextOk; }
      set { SetProperty(ref nextOk, value); }
    }

    public event EventHandler NextPageHandler;

    public bool SaveChanges()
    {

      return true;
    }

    public void GoToNext()
    {
      NextPageEvent();
    }

    private void NextPageEvent()
    {
      var eventDelegate = NextPageHandler;
      eventDelegate?.Invoke(this, null);
    }

    //public ICommand SaveCommand => new RelayCommand(() => { SaveChanges(); });
    public ICommand NextCommand => new RelayCommand((e) => { GoToNext(); });
  }
}
