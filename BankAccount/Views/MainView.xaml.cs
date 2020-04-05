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
  /// Interaction logic for MainView.xaml
  /// </summary>
  public partial class MainView : BaseView
  {
    private MainViewModel viewModel;
    //public event EventHandler ShowNextHandler;
    //public event EventHandler ShowPreviousHandler;
    public MainView(MainViewModel viewModel) : base(viewModel)
    {
      //this.mainViewLayout = new MainViewLayout(viewModel);
      this.viewModel = viewModel;
      
      InitializeComponent();

      var loginViewModel = new LoginViewModel();
      loginViewModel.LoginHandler += LoginViewModel_LoginHandler;
      var loginView = new LoginView(loginViewModel);
      contentControl.Content = loginView;
    }

    private void LoginViewModel_LoginHandler(object sender, EventArgs e)
    {
      viewModel.CurrentPageView = new AccountDetailsView(new AccountDetailsViewModel());
      //mainViewLayout.contentControl.Content = viewModel.CurrentPageView;
      //contentControl.Content = mainViewLayout;
    }

    private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      //if (e.PropertyName == nameof(MainViewModel.CurrentPageView))
      //  mainViewLayout.contentControl.Content = viewModel.CurrentPageView;
    }

    public void ShowNext()
    {
      
    }
  }
}
