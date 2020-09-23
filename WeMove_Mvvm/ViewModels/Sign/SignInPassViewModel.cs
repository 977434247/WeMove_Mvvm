using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using WeMove_Utils;

namespace WeMove_Mvvm.ViewModels.Sign
{

    public class SignInPassViewModel : NotifyPropertyChanged
    {

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value; OnPropertyChanged();
                CanSign = !string.IsNullOrWhiteSpace(password);
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


        public SignInPassViewModel()
        {

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

                        App.Current.Dispatcher.Invoke(() =>
                        {
                            ServiceProvider.Get<SignViewModel>().CurrentView = new Views.Sign.SignInMailView();
                        });
                    });

                });
            });
        }

        public ICommand SignCommand { get; private set; }

    }
}
