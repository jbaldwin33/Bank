using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bank.UIFramework
{
  public class RelayCommand : ICommand
  {
    private readonly Action execute;
    private readonly Action<object> executeWithParameter;
    private readonly Func<object, bool> canExecute;

    public RelayCommand(Action<object> execute) : this(execute, null)
    {
      this.executeWithParameter = execute;
    }

    public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
    {
      this.executeWithParameter = execute ?? throw new ArgumentNullException(nameof(execute));
      this.canExecute = canExecute;
    }

    public RelayCommand(Action execute) : this(execute, null)
    {
      this.execute = execute;
    }

    public RelayCommand(Action execute, Func<object, bool> canExecute)
    {
      this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
      this.canExecute = canExecute;
    }

    public bool CanExecute(object parameter)
    {
      return canExecute == null ? true : canExecute(parameter);
    }

    public void Execute() => execute();

    public void Execute(object parameter) => executeWithParameter(parameter);

    // Ensures WPF commanding infrastructure asks all RelayCommand objects whether their
    // associated views should be enabled whenever a command is invoked 
    public event EventHandler CanExecuteChanged
    {
      add
      {
        CommandManager.RequerySuggested += value;
        CanExecuteChangedInternal += value;
      }
      remove
      {
        CommandManager.RequerySuggested -= value;
        CanExecuteChangedInternal -= value;
      }
    }

    private event EventHandler CanExecuteChangedInternal;

    public void RaiseCanExecuteChanged()
    {
      CanExecuteChangedInternal.Raise(this);
    }
  }

  public static class EventRaiser
  {
    public static void Raise(this EventHandler handler, object sender)
    {
      handler?.Invoke(sender, EventArgs.Empty);
    }

    public static void Raise<T>(this EventHandler<EventArgs<T>> handler, object sender, T value)
    {
      handler?.Invoke(sender, new EventArgs<T>(value));
    }

    public static void Raise<T>(this EventHandler<T> handler, object sender, T value) where T : EventArgs
    {
      handler?.Invoke(sender, value);
    }

    public static void Raise<T>(this EventHandler<EventArgs<T>> handler, object sender, EventArgs<T> value)
    {
      handler?.Invoke(sender, value);
    }
  }

  public class EventArgs<T> : EventArgs
  {
    public EventArgs(T value)
    {
      Value = value;
    }

    public T Value { get; private set; }
  }
}
