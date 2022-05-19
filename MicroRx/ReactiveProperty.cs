using System;
using System.Collections.Generic;

namespace MicroRx
{
    public sealed class ReactiveProperty<T> : IReadOnlyReactiveProperty<T>
    {
        private readonly Subject<T> _Source = new Subject<T>();

        private T _Value;
        public T Value 
        {
            get => _Value;
            set {
                if (!_Value.Equals(value))
                {
                    _Value = value;
                    _Source.OnNext(value);
                }
            }
        }

        private bool _FirstPublished = false;

        public ReactiveProperty()
        {

        }

        public ReactiveProperty(T value)
        {
            Value = value;
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            var disposable = _Source.Subscribe(observer);

            if (!_FirstPublished)
            {
                _Source.OnNext(Value);
                _FirstPublished = true;
            }
            return disposable;
        }
    }
}
