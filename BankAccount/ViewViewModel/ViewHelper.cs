using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bank.MyBank
{
  public class ViewHelper
  {
    internal static void DisplayMessage(object sender, BaseViewModel.MessageBoxNotificationEventArgs e)
    {
      MessageBox.Show(e.Message, e.Caption, e.Buttons, e.Icon);
    }
  }
}
