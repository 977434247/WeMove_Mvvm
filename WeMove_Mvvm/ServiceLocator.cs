using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeMove_Mvvm.Models;
using WeMove_Mvvm.ViewModels;
using WeMove_Mvvm.ViewModels.Sign;
using WeMove_Utils;

namespace WeMove_Mvvm
{
    public class ServiceLocator
    {
        public IconSet IconSet => ServiceProvider.Get<IconSet>();

        public MainViewModel MainViewModel => ServiceProvider.Get<MainViewModel>();
        public SearchViewModel SearchViewModel => ServiceProvider.Get<SearchViewModel>();

        public SignViewModel SignViewModel => ServiceProvider.Get<SignViewModel>();
        public SignInMailViewModel SignInMailViewModel => ServiceProvider.Get<SignInMailViewModel>();
    }
}
