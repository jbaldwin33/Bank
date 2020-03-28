using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Bank.UIFramework.ViewViewModel
{
  /// <summary>
  /// Interaction logic for BaseView.xaml
  /// </summary>
  public class BaseView : UserControl, IView
  {
    public BaseView(BaseViewModel viewModel)
    {
      DataContext = viewModel;
    }

    public IView ShowNext(IView view)
    {
      //return (Parent as Window);
      return null;
    }

    public IView ShowPrevious(IView view)
    {
      (Parent as Page).Content = view;
      return null;
    }
  }
}
