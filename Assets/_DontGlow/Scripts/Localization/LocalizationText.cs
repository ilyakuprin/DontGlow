using TMPro;
using UnityEngine;
using YG;

namespace _DontGlow.Scripts.Localization
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LocalizationText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private TextLocalization _textLocalization;

        public void Change()
        {
            _text.text = YandexGame.savesData.language switch
            {
                "ru" => _textLocalization.Ru,
                "tr" => _textLocalization.Tr,
                _ => _textLocalization.Eu
            };
        }
        
        private void OnValidate()
        {
            _text ??= GetComponent<TextMeshProUGUI>();
        }
    }
}