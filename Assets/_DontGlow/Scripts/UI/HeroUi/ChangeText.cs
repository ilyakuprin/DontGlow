using System;
using _DontGlow.Scripts.MainHero;
using _DontGlow.Scripts.Saves;
using TMPro;
using YG;
using Zenject;

namespace _DontGlow.Scripts.UI.HeroUi
{
    public class ChangeText : IInitializable, IDisposable
    {
        private readonly PickingUpItems _pickingUpItems;
        private readonly CreatingSequenceText _creatingSequence;
        private readonly TextMeshProUGUI _text;
        private readonly Saving _saving;

        private int _nextIndex;

        public ChangeText(PickingUpItems pickingUpItems,
                          CreatingSequenceText creatingSequence,
                          HeroUiView heroUiView,
                          Saving saving)
        {
            _pickingUpItems = pickingUpItems;
            _creatingSequence = creatingSequence;
            _text = heroUiView.Text;
            _saving = saving;
        }
        
        public void Initialize()
        {
            _pickingUpItems.TakenNote += ShowNewText;
            _saving.SaveDataReceived += ChangeCurrentText;
        }

        public void Dispose()
        {
            _pickingUpItems.TakenNote -= ShowNewText;
            _saving.SaveDataReceived -= ChangeCurrentText;
        }

        private void ShowNewText()
        {
            SetText(_nextIndex);
            _nextIndex++;
        }

        private void SetText(int index)
        {
            _text.text = YandexGame.savesData.language switch
            {
                "ru" => _creatingSequence.GetText(index).Ru,
                "tr" => _creatingSequence.GetText(index).Tr,
                _ => _creatingSequence.GetText(index).Eu
            };
        }

        private void ChangeCurrentText()
        {
            if (_nextIndex == 0) return;

            SetText(_nextIndex--);
        }
    }
}