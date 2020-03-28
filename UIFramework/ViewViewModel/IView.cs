using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.UIFramework.ViewViewModel
{
  public interface IView
  {
    IView ShowNext(IView view);
    IView ShowPrevious(IView view);
  }
}
