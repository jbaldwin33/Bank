using Bank.UIFramework;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using static Bank.MyBank.Models.Enums;

namespace Bank.MyBank.Models
{
  public class Account //: NotifyPropertyChanged, IAccount
  {
    public Guid ID { get; private set; }
    public float Balance { get; set; }
    public Guid UserID { get; set; }
    public AccountTypeEnum AccountType { get; set; }

    public Account(float balance, AccountTypeEnum accountType)
    {
      ID = Guid.NewGuid();
      Balance = balance;
      AccountType = accountType;
    }
    
    public void AddToBalance(float amount)
    {
      Balance += amount;
    }
  }
}
