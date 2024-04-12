using System;
using _DontGlow.Scripts.MainHero;
using Zenject;

namespace _DontGlow.Scripts.Objects
{
    public class CounterBattery : IInitializable, IDisposable
    {
        public event Action<int> CountChanged;

        private readonly PickingUpItems _pickingUpItems;

        private int _counter;

        public CounterBattery(PickingUpItems pickingUpItems)
        {
            _pickingUpItems = pickingUpItems;
        }

        public void Initialize()
        {
            _pickingUpItems.TakenBattery += Add;
        }

        public void Dispose()
        {
            _pickingUpItems.TakenBattery += Add;
        }

        private void Add()
        {
            _counter++;
            CountChanged?.Invoke(_counter);
        }
    }
}