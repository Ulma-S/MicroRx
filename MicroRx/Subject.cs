using System;
using System.Collections.Generic;

namespace MicroRx
{
    public sealed class Subject<T> : ISubject<T>
    {
        private readonly List<IObserver<T>> _Observers = new List<IObserver<T>>();

        public void OnNext(T value)
        {
            foreach(var observer in _Observers)
            {
                observer.OnNext(value);
            }
        }

        public void OnError(Exception e)
        {

        }

        public void OnCompleted()
        {
            
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            _Observers.Add(observer);
            return new DisposableObject<T>(this, observer);
        }

        public void Unsubscribe(IObserver<T> observer)
        {
            _Observers.Remove(observer);
        }
    }
}
