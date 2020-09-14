using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WeMove_Utils
{
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// 通知属性更改
        /// </summary>
        /// <param name="propertyName"></param>
        protected void RaisePropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 通知属性更改
        /// </summary>
        /// <param name="propertyName"></param>
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            RaisePropertyChange(propertyName);
        }

        /// <summary>
        /// 通知属性更改事件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;

            OnPropertyChanged(propertyName);

            return true;
        }

        /// <summary>
        /// 通知继承该类的所有属性 属性更改
        /// 慎重使用
        /// </summary>
        protected void RaiseAllChanged()
        {
            RaisePropertyChange("");
        }


        protected object mPropertyValueCheckLock = new object();

        protected async Task RunCommandAsync(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {
            // 线程锁
            lock (mPropertyValueCheckLock)
            {
                // 判断如果是true 则返回 否则就继续执行
                if (updatingFlag.GetPropertyValue())
                    return;

                // 设置属性为true 
                updatingFlag.SetPropertyValue(true);
            }

            try
            {
                // 运行委托
                await action();
            }
            finally
            {
                // 将属性标志设置回false，现在就完成了
                updatingFlag.SetPropertyValue(false);
            }
        }
    }
}
