using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeMove_Mvvm.ViewModels;
using WeMove_Mvvm.ViewModels.Sign;
using WeMove_Utils;

namespace WeMove_Mvvm.Models
{
    public class MainModule : IModule
    {
        public void OnLoad(IBinder binder)
        {
            binder.Bind<IconSet, IconModel>();
            binder.BindSingleton<MainViewModel>();
            binder.BindSingleton<SignViewModel>();
            binder.BindSingleton<SignInMailViewModel>();
            binder.BindSingleton<SignInPassViewModel>();
        }
    }
}
