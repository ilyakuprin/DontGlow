using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace _DontGlow.Scripts.UI.Sound
{
    public class SoundSettings : MonoBehaviour
    {
        private const string Effects = "Effects";
        private const string Music = "Music";
        private const float MinValue = 0.001f;
        
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private Slider _sliderEffects;
        [SerializeField] private Slider _sliderMusic;

        private void OnEnable()
        {
            _sliderEffects.onValueChanged.AddListener(OnSetEffects);
            _sliderEffects.onValueChanged.AddListener(OnSetMusic);
        }

        private void OnDisable()
        {
            _sliderEffects.onValueChanged.RemoveListener(OnSetEffects);
            _sliderEffects.onValueChanged.RemoveListener(OnSetMusic);
        }

        private void OnSetEffects(float value)
            => SetValue(value, Effects);
        
        private void OnSetMusic(float value)
            => SetValue(value, Music);
        
        private void SetValue(float value, string master)
        {
            float volume;

            if (value > MinValue)
            {
                volume = Mathf.Log10(value) * 20;
                _audioMixer.SetFloat(master, volume);
            }
            else
            {
                volume = Mathf.Log10(MinValue) * 20;
                _audioMixer.SetFloat(master, volume);
            }
        }
    }
}