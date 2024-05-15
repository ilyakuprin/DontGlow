using System.Threading;
using _DontGlow.Scripts.Saves;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.Localization
{
    public class ChangeLanguage : MonoBehaviour
    {
        [SerializeField] private LocalizationText[] _localizationTexts;
        [Inject] private Saving _saving;

        private CancellationToken _ct;

        private void Start()
        {
            _ct = this.GetCancellationTokenOnDestroy();
        }

        private void OnEnable()
            => WaitInject().Forget();

        private void OnDisable()
            => _saving.SaveDataReceived -= ChangeText;

        private async UniTask WaitInject()
        {
            while (_saving == null)
            {
                await UniTask.NextFrame(_ct);
            }
            
            _saving.SaveDataReceived += ChangeText;
            
            _saving.DataReceived();
        }

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