using Bank.MyBank.ViewModels;
using Bank.MyBank.ViewViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bank.MyBank.Views
{
  /// <summary>
  /// Interaction logic for LoginView.xaml
  /// </summary>
  public partial class LoginView : BaseView
  {
    private LoginViewModel viewModel;
    public LoginView(LoginViewModel viewModel) : base(viewModel)
    {
      InitializeComponent();
      this.viewModel = viewModel;
      this.viewModel.LoginHandler += LoginHandler;
      this.viewModel.DisplayMessage += DisplayMessageHandler;
    }

    private void DisplayMessageHandler(object sender, BaseViewModel.MessageBoxNotificationEventArgs e)
    {
      MessageBox.Show($"{e.PropertyName} {e.Message}", e.Caption, e.Buttons, e.Icon);
    }

    private void LoginHandler(object sender, EventArgs e)
    {
      if (!viewModel.LoginFailed)
      {
        (Parent as Window).Content = sender as BaseViewModel;
      }
    }
  }
}
