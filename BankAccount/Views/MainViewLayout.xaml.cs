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
  /// Interaction logic for MainViewLayout.xaml
  /// </summary>
  public partial class MainViewLayout : UserControl
  {
    private BaseView[] views;
    private enum PagesEnum { Account, PersonalDetails, Settings };
    private ICommand changePageCommand;
    private ICommand goToAccountDetailsCommand;
    private ICommand goToPersonalDetailsCommand;
    private BaseView currentPageView;
    public MainViewLayout(BaseView[] views)
    {
      if (views == null || views.Count() < 1)
        throw new ArgumentException();

      InitializeComponent();
      this.views = views;
      Show();
    }

    private void Show()
    {
      views[0].Show();
    }

    //public BaseView CurrentPageView
    //{
    //  get => currentPageView;
    //  set
    //  {

    //    SetProperty(ref currentPageView, value);
    //  }
    //}

    private void AccountDetailsCommandExecute(object obj)
    {
      ChangeViewModel(PagesEnum.Account);
    }

    private void PersonalDetailsCommandExecute(object obj)
    {
      ChangeViewModel(PagesEnum.PersonalDetails);
    }

    private void ChangeViewModel(PagesEnum page)
    {
      switch (page)
      {
        case PagesEnum.Account:
          //CurrentPageView = new AccountDetailsView(new AccountDetailsViewModel());
          break;
        case PagesEnum.PersonalDetails:
          //CurrentPageView = new PersonalDetailsView(new PersonalDetailsViewModel());
          break;
        case PagesEnum.Settings:
          //CurrentPageViewModel = new SettingsViiewModel();
          break;
        default:
          throw new NotSupportedException();
      }

      //if (!PageViewModels.Contains(viewModel))
      //  PageViewModels.Add(viewModel);

      //CurrentPageViewModel = PageViewModels
      //    .FirstOrDefault(vm => vm == viewModel);
    }
    //public ICommand GoToAccountDetailsCommand => goToAccountDetailsCommand ?? (goToAccountDetailsCommand = new RelayCommand(AccountDetailsCommandExecute));
    //public ICommand GoToPersonalDetailsCommand => goToPersonalDetailsCommand ?? (goToPersonalDetailsCommand = new RelayCommand(PersonalDetailsCommandExecute));
    //public ICommand ChangePageCommand => changePageCommand ?? (changePageCommand = new RelayCommand(p => ChangeViewModel((PagesEnum)p)));
  }
}
