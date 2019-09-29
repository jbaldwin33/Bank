using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.MyBank;
using System.Runtime.CompilerServices;

namespace Bank.MyBank.Models
{
  public class Account : IAccount
  {
    private double balance;
    public double Balance
    {
      get => balance;
      set
      {
        balance = value;
        SetProperty(ref balance, value);
      }
    }
    public IUser User { get; }
    
    public void AddToBalance(double amount)
    {
      balance += amount;
    }

    public bool SetProperty<T>(ref T fieldName, T value, [CallerMemberName] string propertyName = null)
    {
      if (EqualityComparer<T>.Default.Equals(fieldName, value))
      {
        return false;
      }

      fieldName = value;
      RaisePropertyChanged(propertyName);
      return true;
    }

    protected void RaisePropertyChanged(string propertyName)
    {
      PropertyChangedEventHandler handler = PropertyChanged;
      if (handler != null)
      {
        handler(this, new PropertyChangedEventArgs(propertyName));
      }
    }
    public event PropertyChangedEventHandler PropertyChanged;
  }
}
