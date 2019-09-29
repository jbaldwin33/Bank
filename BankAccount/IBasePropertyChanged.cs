using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Bank.MyBank
{
  public interface IBasePropertyChanged : INotifyPropertyChanged
  {
    bool SetProperty<T>(ref T fieldName, T value, [CallerMemberName] string propertyName = null);
  }
}
