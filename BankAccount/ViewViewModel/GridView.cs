using System;
using System.Data.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Bank.MyBank
{
  public class GridView : Grid, IView
  {
    public GridView(BaseViewModel viewModel) : base()
    {
      if (viewModel == null)
        throw new ArgumentNullException(nameof(viewModel));
      DataContext = viewModel;
      viewModel.DisplayMessage += ViewHelper.DisplayMessage;
    }

    public GridView() : base()
    {
      if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
      {
        throw new InvalidOperationException("Default constructor can only be used in designer mode.");
      }
    }

    public BaseViewModel ViewModel
    {
      get { return (BaseViewModel)DataContext; }
    }

    public void Showing()
    {
      ViewModel.Showing();
      //ViewHelper.Showing(this);
    }

    public Boolean Closing()
    {
      //if (ViewHelper.Closing(this))
      //  return ViewModel.Closing();
      //else
        return true;
    }

    public void Closed()
    {
      //ViewHelper.Closing(this);
      ViewModel.Closed();
    }
  }
}
