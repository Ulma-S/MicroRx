using System;

namespace MicroRx
{
    public sealed class Observer<T> : IObserver<T>
    {
        private readonly Action<T> _OnNext;
        private readonly Action _OnCompleted;
        private readonly Action<System.Exception> _OnError;

        public Observer(Action<T> onNext)
        {
            _OnNext = onNext;
        }

        public Observer(Action<T> onNext, Action onCompleted)
        {
            _OnNext = onNext;
            _OnCompleted = onCompleted;
        }

        public void OnNext(T value)
        {
            _OnNext?.Invoke(value);
        }

        public void OnCompleted()
        {
            _OnCompleted?.Invoke();
        }

        public void OnError(Exception e)
        {
            _OnError?.Invoke(e);
        }
    }
}
