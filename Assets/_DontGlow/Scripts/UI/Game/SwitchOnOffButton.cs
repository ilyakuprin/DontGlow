using System;
using _DontGlow.Scripts.Flashlight;
using _DontGlow.Scripts.ScriptableObj;
using Zenject;

namespace _DontGlow.Scripts.UI.Game
{
    public class SwitchOnOffButton : IInitializable, IDisposable
    {
        private readonly OnOffButton _onOffButton;
        private readonly UiInGameView _uiInGameView;
        private readonly FlashlightConfig _flashlightConfig;

        public SwitchOnOffButton(OnOffButton onOffButton,
                                 UiInGameView uiInGameView,
                                 FlashlightConfig flashlightConfig)
        {
            _onOffButton = onOffButton;
            _uiInGameView = uiInGameView;
            _flashlightConfig = flashlightConfig;
        }

        public void Initialize()
        {
            _onOffButton.Offed += ShowOff;
            _onOffButton.Oned += ShowOn;
        }

        public void Dispose()
        {
            _onOffButton.Offed -= ShowOff;
            _onOffButton.Oned -= ShowOn;
        }

        private void ShowOff()
            => _uiInGameView.OnOffFlashlightImage.sprite = _flashlightConfig.Off;
        
        private void ShowOn()
            => _uiInGameView.OnOffFlashlightImage.sprite = _flashlightConfig.On;
    }
}