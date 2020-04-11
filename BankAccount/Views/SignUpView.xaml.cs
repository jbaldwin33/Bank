using Bank.MyBank.ViewModels;
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
  /// Interaction logic for SignUpView.xaml
  /// </summary>
  public partial class SignUpView : BaseView
  {
    private SignUpViewModel viewModel;
    public SignUpView(SignUpViewModel viewModel) : base(viewModel)
    {
      InitializeComponent();
      this.viewModel = viewModel;
      viewModel.SignUpHandler += SignUpHandler;

    }

    private void SignUpHandler(object sender, EventArgs e)
    {
      if (viewModel.SignUpComplete)
        (Parent as Window).Content = new AccountDetailsView(new AccountDetailsViewModel());
    }
  }
}
