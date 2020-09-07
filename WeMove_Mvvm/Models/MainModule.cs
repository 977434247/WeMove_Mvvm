using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeMove_Utils;

namespace WeMove_Mvvm.Models
{
    public class MainModule : IModule
    {
        public void OnLoad(IBinder binder)
        {
            binder.Bind<IconSet, IconModel>();
        }
    }
}
