using Bank.MyBank.Views;
using Bank.UIFramework;
using Bank.UIFramework.ViewViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bank.MyBank.ViewModels
{
  public class MainViewModel : BaseViewModel
  {
    private enum PagesEnum { Account, PersonalDetails, Settings };
    private ICommand changePageCommand;
    private ICommand goToAccountDetailsCommand;
    private ICommand goToPersonalDetailsCommand;
    private BaseView currentPageView;
    //private List<BaseViewModel> pageViewModels;

    public MainViewModel()
    {
      // Add available pages
      //PageViewModels.Add(new AccountDetailsViewModel());

      //// Set starting page
      //CurrentPageViewModel = PageViewModels[0];
    }

    //public List<BaseViewModel> PageViewModels
    //{
    //  get
    //  {
    //    if (pageViewModels == null)
    //      pageViewModels = new List<BaseViewModel>();

    //    return pageViewModels;
    //  }
    //}

    public BaseView CurrentPageView
    {
      get => currentPageView;
      set
      {

        SetProperty(ref currentPageView, value);
      }
    }

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
          CurrentPageView = new AccountDetailsView(new AccountDetailsViewModel());
          break;
        case PagesEnum.PersonalDetails:
          CurrentPageView = new PersonalDetailsView(new PersonalDetailsViewModel());
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
    public ICommand GoToAccountDetailsCommand => goToAccountDetailsCommand ?? (goToAccountDetailsCommand = new RelayCommand(AccountDetailsCommandExecute));
    public ICommand GoToPersonalDetailsCommand => goToPersonalDetailsCommand ?? (goToPersonalDetailsCommand = new RelayCommand(PersonalDetailsCommandExecute));
    public ICommand ChangePageCommand => changePageCommand ?? (changePageCommand = new RelayCommand(p => ChangeViewModel((PagesEnum)p)));
  }
}
