using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Bank.UIFramework.ViewViewModel
{
  public class ViewLayout : Page, IView
  {
    public readonly IEnumerable<IView> views;

    public ViewLayout(IEnumerable<IView> views)
    {
      this.views = views;
    }

    public IView ShowNext(IView view)
    {
      return views.First(v => v == view);
    }

    public IView ShowPrevious(IView view)
    {
      return views.First(v => v == view);
    }
  }
}
