using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.MyBank
{
  public interface IView
  {
    void Showing();

    Boolean Closing();

    void Closed();
  }
}
