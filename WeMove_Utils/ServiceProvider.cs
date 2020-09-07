using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeMove_Utils
{
    public class ServiceProvider
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
        public static void LoadModule(IModule module)
        {
            kernel.Load(new Binder(module));

        }
    }
}
