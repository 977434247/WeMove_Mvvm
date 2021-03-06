﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WeMove_Mvvm.Models;
using WeMove_Utils;

namespace WeMove_Mvvm.ViewModels
{
    public class MainViewModel : NotifyPropertyChanged
    {


        public MainViewModel()
        {
            MinimCommand = new RelyCommand(() =>
            {
                App.Current.MainWindow.WindowState = WindowState.Minimized;
            });

            CloseCommand = new RelyCommand(() =>
            {
                App.Current.MainWindow.Close();
            });


        }

        public ICommand MinimCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }


    }
}