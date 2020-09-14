using System;
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

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value; OnPropertyChanged();
                CanSign = !string.IsNullOrWhiteSpace(email);
            }
        }

        private bool canSign;

        /// <summary>
        /// ture: Can Sign false:No
        /// </summary>
        public bool CanSign
        {
            get { return canSign; }
            set
            {
                canSign = value; OnPropertyChanged();
            }
        }


        private bool isSigning;

        public bool IsSigning
        {
            get { return isSigning; }
            set { isSigning = value; OnPropertyChanged(); }
        }


        public MainViewModel()
        {
            Email = "977434247@qq.com";
            MinimCommand = new RelyCommand(() =>
            {
                App.Current.MainWindow.WindowState = WindowState.Minimized;
            });

            CloseCommand = new RelyCommand(() =>
            {
                App.Current.MainWindow.Close();
            });

            //SignCommand = new RelyCommand(() =>
            //{
            //    if (IsSigning)
            //    {
            //        return;
            //    }
            //    IsSigning = true;
            //    Task.Run(() =>
            //    {

            //        //验证
            //        Thread.Sleep(2000);

            //        //验证完成后  判断如果失败则继续停留当前窗口
            //        IsSigning = false;
            //    });
            //});

            SignCommand = new RelyCommand(async () =>
            {
                await RunCommandAsync(() => IsSigning, async () =>
                 {
                     await Task.Run(() =>
                     {
                         Thread.Sleep(2000);
                     });
                 });
            });
        }

        public ICommand MinimCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }

        public ICommand SignCommand { get; private set; }

    }
}