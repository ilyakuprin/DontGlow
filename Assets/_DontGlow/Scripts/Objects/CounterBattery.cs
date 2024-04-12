using System;
using _DontGlow.Scripts.MainHero;
using Zenject;

namespace _DontGlow.Scripts.Objects
{
    public class CounterBattery : IInitializable, IDisposable
    {
        public event Action<int> CountChanged;

        private readonly PickingUpItems _pickingUpItems;

        public int Count { get; private set; }

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
        
        public void Subtract()
        {
            if (Count > 0)
            {
                Count--;
                CountChanged?.Invoke(Count);
            }
            else
            {
                throw new Exception("Value cant be < 0");
            }
        }
        
        private void Add()
        {
            Count++;
            CountChanged?.Invoke(Count);
        }
    }
}