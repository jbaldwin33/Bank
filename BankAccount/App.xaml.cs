using System;
using System.Windows;
using System.Windows.Controls;
using Bank.MyBank.Views;
using Bank.MyBank.ViewModels;

namespace Bank.MyBank
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    private void On_Startup(object sender, StartupEventArgs e)
    {
      base.OnStartup(e);
      MainWindow window = new MainWindow();
      AccountDetailsViewModel vm = new AccountDetailsViewModel();
      window.DataContext = vm;
      window.Show();
    }
  }
}
