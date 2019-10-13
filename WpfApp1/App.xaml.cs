using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Bank.MyBank.ViewModels;
using Bank.MyBank.Views;
using Bank.MyBank.Models;

namespace WpfApp1
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    private void On_Startup(object sender, StartupEventArgs e)
    {
      AccountDetailsView mw = new AccountDetailsView();
      AccountDetailsViewModel viewModel = new AccountDetailsViewModel();
      Account model = new Account();
      mw.Show();
    }
  }
}
