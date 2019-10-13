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
  public class Account : NotifyPropertyChanged, IAccount
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
  }
}
