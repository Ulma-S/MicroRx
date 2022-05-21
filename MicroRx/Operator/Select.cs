namespace MicroRx.Operator
{
    public class SelectOperator<T> : IObservable<T>
    {
        private readonly IObservable<T> _Source;
        private readonly System.Func<T, T> _SelectFunc;

        public SelectOperator(IObservable<T> source, System.Func<T, T> selectFunc)
        {
            _Source = source;
            _SelectFunc = selectFunc;
        }

        public System.IDisposable Subscribe(IObserver<T> observer)
        {
            return new SelectObserver(this, observer).Run();
        }

        private class SelectObserver : IObserver<T>
        {
            private readonly SelectOperator<T> _Parent;
            private readonly IObserver<T> _Observer;

            public SelectObserver(SelectOperator<T> parent, IObserver<T> observer)
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
                if(_Parent._SelectFunc == null)
                {
                    return;
                }

                var result = _Parent._SelectFunc.Invoke(value);

                _Observer.OnNext(result);
            }
         
            public void OnCompleted()
            {
                _Observer.OnCompleted();
            }

            public void OnError(System.Exception e)
            {
                _Observer.OnError(e);
            }
        }
    }
}
