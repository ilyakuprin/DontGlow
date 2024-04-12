using System;
using _DontGlow.Scripts.UI;
using Zenject;

namespace _DontGlow.Scripts.Flashlight
{
    public class OnOffButton : IInitializable, IDisposable
    {
        public event Action Offed; 
        public event Action Oned; 
        
        private readonly UiInGameView _uiInGameView;
        private bool _isOn = true;

        public OnOffButton(UiInGameView uiInGameView)
        {
            _uiInGameView = uiInGameView;
        }

        public void Initialize()
        {
            _uiInGameView.OnOffFlashlight.onClick.AddListener(ChangeState);
        }

        public void Dispose()
        {
            _uiInGameView.OnOffFlashlight.onClick.RemoveListener(ChangeState);
        }

        private void ChangeState()
        {
            _isOn = !_isOn;
            
            if (_isOn)
                Oned?.Invoke();
            else
                Offed?.Invoke();
        }
    }
}