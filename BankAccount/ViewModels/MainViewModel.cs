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
    private ICommand changePageCommand;
    private BaseViewModel currentPageViewModel;
    private List<BaseViewModel> pageViewModels;


    public MainViewModel()
    {
      // Add available pages
      PageViewModels.Add(new AccountDetailsViewModel());

      // Set starting page
      CurrentPageViewModel = PageViewModels[0];
    }

    public ICommand ChangePageCommand
    {
      get
      {
        if (changePageCommand == null)
        {
          changePageCommand = new RelayCommand(
              p => ChangeViewModel((BaseViewModel)p),
              p => p is BaseViewModel);
        }

        return changePageCommand;
      }
    }

    public List<BaseViewModel> PageViewModels
    {
      get
      {
        if (pageViewModels == null)
          pageViewModels = new List<BaseViewModel>();

        return pageViewModels;
      }
    }

    public BaseViewModel CurrentPageViewModel
    {
      get => currentPageViewModel;
      set => SetProperty(ref currentPageViewModel, value);
    }

    private void ChangeViewModel(BaseViewModel viewModel)
    {
      if (!PageViewModels.Contains(viewModel))
        PageViewModels.Add(viewModel);

      CurrentPageViewModel = PageViewModels
          .FirstOrDefault(vm => vm == viewModel);
    }
  }
}
