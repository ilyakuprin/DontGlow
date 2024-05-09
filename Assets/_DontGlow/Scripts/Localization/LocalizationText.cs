using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using YG;

namespace _DontGlow.Scripts.Localization
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LocalizationText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [field: FormerlySerializedAs("_textLocalization")] [field: SerializeField] public TextLocalization TextLocalization
        {
            get;
            private set;
        }

        public virtual void Change()
        {
            var text = YandexGame.savesData.language switch
            {
                "ru" => TextLocalization.Ru,
                "tr" => TextLocalization.Tr,
                _ => TextLocalization.Eu
            };
            
            Set(text);
        }

        protected void Set(string text)
        {
            _text.text = text;
        }
        
        private void OnValidate()
        {
            _text ??= GetComponent<TextMeshProUGUI>();
        }
    }
}