using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.MyBank.Models
{
  public interface IAccount : IBasePropertyChanged
  {
    double Balance { get; set; }
    IUser User { get; }
  }
}
