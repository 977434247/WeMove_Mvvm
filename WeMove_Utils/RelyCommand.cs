using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WeMove_Utils
{
    public class RelyCommand : ICommand
    {
        Action mAction;

        public RelyCommand(Action action)
        {
            mAction = action;
        }

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mAction?.Invoke();
        }
    }


    public class RelyCommand<T> : ICommand
    {
        Action<T> mAction;

        public RelyCommand(Action<T> action)
        {
            mAction = action;
        }

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mAction?.Invoke((T)parameter);
        }
    }
}
