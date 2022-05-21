namespace MicroRx.Operator
{
    public class TakeOperator<T> : IObservable<T>
    {
        private readonly IObservable<T> _Source;
        private readonly int _TakeCount;

        public TakeOperator(IObservable<T> source, int takeCount)
        {
            _Source = source;
            _TakeCount = takeCount;
        }

        public System.IDisposable Subscribe(IObserver<T> observer)
        {
            return new TakeObserver(this, observer).Run();
        }

        private class TakeObserver : IObserver<T>
        {
            private readonly TakeOperator<T> _Parent;
            private readonly IObserver<T> _Observer;
            private int _PublishedCount = 0;
            private bool _CompletePublished = false;

            public TakeObserver(TakeOperator<T> parent, IObserver<T> observer)
            {
                _Parent = parent;
                _Observer = observer;
            }

            public System.IDisposable Run()
            {
                return _Parent._Source.Subscribe(this);
            }

            public void OnNext(T value)
            {
                if(_PublishedCount >= _Parent._TakeCount)
                {
                    if (!_CompletePublished)
                    {
                        _Observer.OnCompleted();
                        _CompletePublished = true;
                    }
                    return;
                }

                _Observer.OnNext(value);
                _PublishedCount++;
            }

            public void OnError(System.Exception e)
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
