﻿using Bank.MyBank.Models;
using Bank.MyBank.ViewModels;
using Bank.MyBank.Views;
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
      var loginView = new LoginView(loginViewModel);

      var mainView = new MainView();
      mainView.Content = loginView;
      mainView.Show();
    }
  }
}
