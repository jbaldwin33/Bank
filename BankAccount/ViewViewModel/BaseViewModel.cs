using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bank.MyBank
{
  public abstract class BaseViewModel : NotifyPropertyChanged
  {
    protected virtual void OnShowing() { }

    protected virtual Boolean OnClosing()
    {
      return true;
    }

    protected virtual void OnClosed() { }

    internal void Showing()
    {
      OnShowing();
    }

    internal Boolean Closing()
    {
      return OnClosing();
    }

    internal void Closed()
    {
      OnClosed();
    }

    public event EventHandler<MessageBoxNotificationEventArgs> DisplayMessage;

    protected void OnDisplayMessage(string message, string caption, MessageBoxButton buttons, MessageBoxImage icon, string propertyName = "")
    {
      var eventDelegate = DisplayMessage;
      eventDelegate?.Invoke(this, new MessageBoxNotificationEventArgs(message, caption, buttons, icon, propertyName));
    }

    public class MessageBoxNotificationEventArgs
    {
      public MessageBoxNotificationEventArgs(string message, string caption, MessageBoxButton buttons, MessageBoxImage icon, string propertyName = "")
      {
        Message = message;
        Caption = caption;
        Buttons = buttons;
        Icon = icon;
        PropertyName = propertyName;
      }
      public string Message { get; private set; }
      public string Caption { get; private set; }
      public MessageBoxButton Buttons { get; private set; }
      public MessageBoxImage Icon { get; private set; }
      public string PropertyName { get; private set; }
    }
  }
}
