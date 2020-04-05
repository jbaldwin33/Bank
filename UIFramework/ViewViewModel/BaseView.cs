using System;
using System.Collections.Generic;
using System.ComponentModel;
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
  public class BaseView : Window, IView
  {
    protected bool IsShown { get; set; }
    protected BaseViewModel ViewModel { get; private set; }
    public BaseView(BaseViewModel viewModel)
    {
      ViewModel = viewModel;
      ViewModel.PropertyChanged += ViewModel_PropertyChanged;
      DataContext = viewModel;
    }

    protected virtual void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e) { }

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
