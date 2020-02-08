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
  public partial class BaseView : Page
  {
    public BaseView(BaseViewModel viewModel)
    {
      InitializeComponent();
      DataContext = viewModel;
    }

    public virtual void GoToNext()
    {

    }

    protected virtual void GoToPrevious()
    {

    }
  }
}
