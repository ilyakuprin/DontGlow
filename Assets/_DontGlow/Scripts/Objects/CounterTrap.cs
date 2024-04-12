using System;
using _DontGlow.Scripts.MainHero;
using Zenject;

namespace _DontGlow.Scripts.Objects
{
    public class CounterTrap : IInitializable, IDisposable
    {
        public event Action<int> CountChanged; 
        
        private readonly PickingUpItems _pickingUpItems;

        private int _counter;

        public CounterTrap(PickingUpItems pickingUpItems)
        {
            _pickingUpItems = pickingUpItems;
        }

        public void Initialize()
        {
            _pickingUpItems.TakenTrap += Add;
        }

        public void Dispose()
        {
            _pickingUpItems.TakenTrap += Add;
        }

        private void Add()
        {
            _counter++;
            CountChanged?.Invoke(_counter);
        }
    }
}