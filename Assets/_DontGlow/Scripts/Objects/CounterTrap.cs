using System;
using _DontGlow.Scripts.MainHero;
using _DontGlow.Scripts.UI;
using _DontGlow.Scripts.UI.Game;
using Zenject;

namespace _DontGlow.Scripts.Objects
{
    public class CounterTrap : IInitializable, IDisposable
    {
        public event Action<int> CountChanged;
        public event Action Reduced;
        
        private readonly PickingUpItems _pickingUpItems;
        private readonly UiInGameView _uiInGameView;

        private int _counter;

        public CounterTrap(PickingUpItems pickingUpItems,
                           UiInGameView uiInGameView)
        {
            _pickingUpItems = pickingUpItems;
            _uiInGameView = uiInGameView;
        }

        public void Initialize()
        {
            _pickingUpItems.TakenTrap += Add;
            _uiInGameView.TrapButton.onClick.AddListener(Reduce);
        }

        public void Dispose()
        {
            _pickingUpItems.TakenTrap += Add;
            _uiInGameView.TrapButton.onClick.RemoveListener(Reduce);
        }

        private void Add()
        {
            _counter++;
            CountChanged?.Invoke(_counter);
        }

        private void Reduce()
        {
            if (_counter <= 0) return;
            
            _counter--;
            CountChanged?.Invoke(_counter);
            Reduced?.Invoke();
        }
    }
}