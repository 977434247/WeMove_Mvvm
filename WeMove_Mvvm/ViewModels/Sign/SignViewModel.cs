﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WeMove_Mvvm.Views.Sign;
using WeMove_Utils;

namespace WeMove_Mvvm.ViewModels.Sign
{
    public class SignViewModel : NotifyPropertyChanged
    {
        public SignViewModel()
        {
            MinimCommand = new RelyCommand(() =>
            {
                App.Current.MainWindow.WindowState = WindowState.Minimized;
            });

            CloseCommand = new RelyCommand(() =>
            {
                App.Current.MainWindow.Close();
            });

            CurrentView = new SignInMailView();
        }



        private FrameworkElement currentView;

        public FrameworkElement CurrentView
        {
            get { return currentView; }
            set { currentView = value; OnPropertyChanged(); }
        }

        public ICommand MinimCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }

    }
}
