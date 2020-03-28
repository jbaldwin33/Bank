﻿using Bank.MyBank.ViewModels;
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
  /// Interaction logic for MainViewLayout.xaml
  /// </summary>
  public partial class MainViewLayout : UserControl
  {
    public MainViewLayout(MainViewModel viewModel)
    {
      InitializeComponent();
      DataContext = viewModel;
    }
  }
}
