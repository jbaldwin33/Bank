using Bank.MyBank.ViewModels;
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
  public partial class AccountDetailsView : Window
  {
    private AccountDetailsViewModel viewModel;
    public AccountDetailsView(AccountDetailsViewModel viewModel) : base()
    {
      InitializeComponent();
      this.viewModel = viewModel;
      DataContext = viewModel;
    }

    public void GoToNextPage()
    {
      
    }
  }
}
