using System;

namespace MicroRx.Operator
{
    public sealed class WhereOperator<T> : IObservable<T>
    {
        private readonly IObservable<T> _Source;
        private Func<T, bool> _ConditionalFunc;

        public WhereOperator(IObservable<T> source, Func<T, bool> conditionalFunc) 
        {
            _Source = source;
            _ConditionalFunc = conditionalFunc;
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            return new WhereObserver(this, observer).Run();
        }

        private class WhereObserver : IObserver<T>
        {
            private readonly WhereOperator<T> _Parent;
            private readonly IObserver<T> _Observer;

            public WhereObserver(WhereOperator<T> parent, IObserver<T> observer) 
            {
                _Parent = parent;
                _Observer = observer;
            }

            public IDisposable Run()
            {
                return _Parent._Source.Subscribe(this);
            }

            public void OnNext(T value)
            {
                if (!_Parent._ConditionalFunc(value))
                {
                    return;
                }

                _Observer.OnNext(value);
            }

            public void OnError(Exception e)
            {
                _Observer.OnError(e);
            }

            public void OnCompleted()
            {
                _Observer.OnCompleted();
            }
        }
    }
}
