using _DontGlow.Scripts.Localization;
using _DontGlow.Scripts.ScriptableObj;
using Zenject;
using UnityEngine;

namespace _DontGlow.Scripts.UI.HeroUi
{
    public class CreatingSequenceText : IInitializable
    {
        private readonly HeroTextConfig _heroTextConfig;
        
        private TextLocalization[] _heroText;

        public CreatingSequenceText(HeroTextConfig heroTextConfig)
        {
            _heroTextConfig = heroTextConfig;
        }

        public int Length => _heroText.Length;

        public TextLocalization GetText(int index)
            => _heroText[index];

        public void Initialize()
        {
            FillArray();
            MixTextWithoutFirstAndLast();
        }

        private void FillArray()
        {
            _heroText = new TextLocalization[_heroTextConfig.LengthAllText];

            _heroText[0] = _heroTextConfig.FirstText;
            
            for (var i = 0; i < _heroTextConfig.LengthAllText - 2; i++)
            {
                _heroText[i + 1] = _heroTextConfig.GetText(i);
            }
            
            _heroText[^1] = _heroTextConfig.LastText;
        }

        private void MixTextWithoutFirstAndLast()
        {
            for (var i = _heroText.Length - 2; i > 1; i--)
            {
                var randomIndex = Random.Range(1, i + 1);
                (_heroText[randomIndex], _heroText[i]) = (_heroText[i], _heroText[randomIndex]);
            }
        }
    }
}