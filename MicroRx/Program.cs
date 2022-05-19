using System;
using MicroRx;

namespace MicroRx.Sample
{
    class Program
    {
        private enum Type
        {
            A,
            B,
            C,
            D,
        }

        static void Main(string[] args)
        {
            var num = new ReactiveProperty<int>();

            num.Where(value => value %2 == 0).Subscribe(value => {
                Console.WriteLine(value);
            });

            num.Value = 1;
            num.Value = 2;
            num.Value = 3;
            num.Value = 4;

            var type = new ReactiveProperty<Type>(Type.A);

            type.Subscribe(value => {
                Console.WriteLine(value);
            });

            type.Value = Type.B;
        }
    }
}
