using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeMove_Mvvm.Models;
using WeMove_Mvvm.ViewModels;

namespace WeMove_Mvvm
{
    public class Di
    {

        static IKernel kernel { get; } = new StandardKernel();

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>() => kernel.Get<T>();

        /// <summary>
        /// 加载/注册 依赖关系
        /// </summary>
        public static void LoadModule()
        {
            kernel.Bind<IconSet>().To<IconModel>().InSingletonScope();
            kernel.Bind<MainViewModel>().ToSelf().InSingletonScope();
        }
    }
}
