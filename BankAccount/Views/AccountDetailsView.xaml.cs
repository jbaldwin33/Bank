﻿using Bank.MyBank.ViewModels;
using Bank.UIFramework.ViewViewModel;
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
  /// Interaction logic for AccountDetailsView.xaml
  /// </summary>
  public partial class AccountDetailsView : BaseView
  {
    private AccountDetailsViewModel viewModel;

    public AccountDetailsView(AccountDetailsViewModel viewModel) : base(viewModel)
    {
      InitializeComponent();
      this.viewModel = viewModel;
    }

  }
}
