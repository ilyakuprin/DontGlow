using _DontGlow.Scripts.Saves;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.Localization
{
    public class ChangeLanguage : MonoBehaviour
    {
        [SerializeField] private LocalizationText[] _localizationTexts;
        [Inject] private Saving _saving;
        
        private void OnEnable()
            => _saving.SaveDataReceived += ChangeText;

        private void OnDisable()
            => _saving.SaveDataReceived += ChangeText;

        private void ChangeText()
        {
            foreach (var text in _localizationTexts)
            {
                text.Change();
            }
        }

        private void OnValidate()
            => _localizationTexts =
                FindObjectsByType<LocalizationText>(FindObjectsInactive.Include, FindObjectsSortMode.None);
    }
}