using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRx
{
    public sealed class Observer<T> : IObserver<T>
    {
        private event Action<T> _OnNotified;

        public Observer(Action<T> onNotified)
        {
            _OnNotified = onNotified;
        }

        public void OnNext(T value)
        {
            _OnNotified?.Invoke(value);
        }

        public void OnCompleted()
        {
            
        }

        public void OnError(Exception e)
        {
        
        }
    }
}
