using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRx
{
    public class DisposableObject<T> : IDisposable
    {
        private readonly ISubject<T> _Source;
        private readonly IObserver<T> _Observer;

        public DisposableObject(ISubject<T> source, IObserver<T> observer)
        {
            _Source = source;
            _Observer = observer;
        }

        public void Dispose()
        {
            _Source.Unsubscribe(_Observer);
        }
    }
}
