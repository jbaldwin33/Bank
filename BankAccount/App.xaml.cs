using Bank.MyBank.Models;
using Bank.MyBank.ViewModels;
using Bank.MyBank.Views;
using Bank.UIFramework.ViewViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Bank.MyBank
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    private void On_Startup(object sender, StartupEventArgs e)
    {
      var loginViewModel = new LoginViewModel();
      loginViewModel.LoginHandler += LoginViewModel_LoginHandler;

      var views = new BaseView[]
      {
        new LoginView(loginViewModel),
        new AccountDetailsView(new AccountDetailsViewModel()),
        new PersonalDetailsView(new PersonalDetailsViewModel())
      };

      new MainViewLayout(views);
    }


    private void LoginViewModel_LoginHandler(object sender, EventArgs e)
    {
      
    }
  }
}
