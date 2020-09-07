 namespace WeMove_Utils
{
    public interface IBinder
    {
        void Bind<TFrom, TTarget>(bool isSingleton = true) where TTarget : TFrom;

        void BindSingleton<T>();

        T Get<T>();
    }
}
