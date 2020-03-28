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
  public class PersonalDetailsViewModel : BaseViewModel
  {
    private string firstName;
    private string lastName;

    public PersonalDetailsViewModel()
    {
      FirstName = "Josh";
    }

    public string FirstName
    {
      get { return firstName; }
      set { SetProperty(ref firstName, value); }
    }

    public string LastName
    {
      get { return lastName; }
      set { SetProperty(ref lastName, value); }
    }

    public event EventHandler GoBackHandler;

    private void GoBack()
    {
      GoBackEvent();
    }

    private void GoBackEvent()
    {
      var eventDelegate = GoBackHandler;
      eventDelegate?.Invoke(this, null);
    }

    public ICommand BackCommand => new RelayCommand((e) => GoBack());
  }
}
