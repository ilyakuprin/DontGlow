using System;
using _DontGlow.Scripts.Saves;
using UnityEngine;
using YG;
using Zenject;

namespace _DontGlow.Scripts.UI.Sound
{
    public class SoundSettings : IInitializable, IDisposable
    {
        private const string Effects = "Effects";
        private const string Music = "Music";
        private const float MinValue = 0.001f;
        
        private readonly Saving _saving;
        private readonly SettingsView _settingsView;

        public SoundSettings(Saving saving,
                             SettingsView settingsView)
        {
            _saving = saving;
            _settingsView = settingsView;
        }

        public void Initialize()
        {
            _saving.SaveDataReceived += SetSavesValue;
            
            _settingsView.SliderEffects.onValueChanged.AddListener(OnSetEffects);
            _settingsView.SliderMusic.onValueChanged.AddListener(OnSetMusic);
        }

        public void Dispose()
        {
            _saving.SaveDataReceived -= SetSavesValue;
            
            _settingsView.SliderEffects.onValueChanged.RemoveListener(OnSetEffects);
            _settingsView.SliderMusic.onValueChanged.RemoveListener(OnSetMusic);
        }

        private void OnSetEffects(float valueSlider)
        {
            SetVolume(valueSlider, Effects);
            Save(valueSlider, Effects);
        }

        private void OnSetMusic(float valueSlider)
        {
            SetVolume(valueSlider, Music);
            Save(valueSlider, Music);
        }

        private void SetVolume(float valueSlider, string master)
        {
            float volume;
            
            if (valueSlider > MinValue)
            {
                volume = Mathf.Log10(valueSlider) * 20;
                _settingsView.Mixer.SetFloat(master, volume);
            }
            else
            {
                volume = Mathf.Log10(MinValue) * 20;
                _settingsView.Mixer.SetFloat(master, volume);
            }
        }

        private void SetSavesValue()
        {
            SetVolume(YandexGame.savesData.ValueSliderEffects, Effects);
            _settingsView.SliderEffects.value = YandexGame.savesData.ValueSliderEffects;
            
            SetVolume(YandexGame.savesData.ValueSliderMusic, Music);
            _settingsView.SliderMusic.value = YandexGame.savesData.ValueSliderMusic;
        }

        private void Save(float valueSlider, string master)
        {
            switch (master)
            {
                case Effects:
                    YandexGame.savesData.ValueSliderEffects = valueSlider;
                    break;
                case Music:
                    YandexGame.savesData.ValueSliderMusic = valueSlider;
                    break;
            }
            
            _saving.Save();
        }
    }
}