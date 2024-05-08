using System;
using _DontGlow.Scripts.MainHero;
using TMPro;
using Zenject;

namespace _DontGlow.Scripts.UI.HeroUi
{
    public class ChangeText : IInitializable, IDisposable
    {
        private readonly PickingUpItems _pickingUpItems;
        private readonly CreatingSequenceText _creatingSequence;
        private readonly TextMeshProUGUI _text;

        private int _currentIndex;

        public ChangeText(PickingUpItems pickingUpItems,
                          CreatingSequenceText creatingSequence,
                          HeroUiView heroUiView)
        {
            _pickingUpItems = pickingUpItems;
            _creatingSequence = creatingSequence;
            _text = heroUiView.Text;
        }
        
        public void Initialize()
            => _pickingUpItems.TakenNote += Change;

        public void Dispose() 
            => _pickingUpItems.TakenNote -= Change;

        private void Change()
        {
            _text.text = _creatingSequence.GetText(_currentIndex).Ru;
            _currentIndex++;
        }
    }
}