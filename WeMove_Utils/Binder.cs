using Ninject.Modules;
using System.Collections.Generic;

namespace WeMove_Utils
{
    public class Binder : NinjectModule, IBinder
    {
        private readonly IModule module;

        public Binder(IModule module)
        {
            this.module = module;
        }

        public void Bind<TFrom, TTarget>(bool isSingleton = true) where TTarget : TFrom
        {
            var binding = Bind<TFrom>().To<TTarget>();

            if (isSingleton)
                binding.InSingletonScope();
        }

        public void BindSingleton<T>()
        {
            Bind<T>().ToSelf().InSingletonScope();
        }

        public T Get<T>()
        {
            return ServiceProvider.Get<T>();
        }

        public override void Load()
        {
            module.OnLoad(this);
        }

    }
}