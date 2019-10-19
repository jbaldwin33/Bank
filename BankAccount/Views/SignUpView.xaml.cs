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
  /// Interaction logic for SignUpView.xaml
  /// </summary>
  public partial class SignUpView : UserControl
  {
    private SignUpViewModel viewModel;
    public SignUpView(SignUpViewModel viewModel)
    {
      InitializeComponent();
      this.viewModel = viewModel;
      DataContext = viewModel;
      viewModel.SignUpHandler += SignUpHandler;

    }

    private void SignUpHandler(object sender, EventArgs e)
    {
      if (viewModel.SignUpComplete)
        this.Content = new AccountDetailsView(new AccountDetailsViewModel());
    }
  }
}
