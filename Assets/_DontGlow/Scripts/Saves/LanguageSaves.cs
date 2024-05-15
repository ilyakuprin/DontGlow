using System;
using _DontGlow.Scripts.UI.Sound;
using UnityEngine;
using YG;
using Zenject;

namespace _DontGlow.Scripts.Saves
{
    public class LanguageSaves : IInitializable, IDisposable
    {
        private readonly Saving _saving;
        private readonly SettingsView _settingsView;

        public LanguageSaves(Saving saving,
                             SettingsView settingsView)
        {
            _saving = saving;
            _settingsView = settingsView;
        }

        public void Initialize()
        {
            _saving.SaveDataReceived += SetDropdown;

            _settingsView.Dropdown.onValueChanged.AddListener(SetLanguage);
        }

        public void Dispose()
        {
            _saving.SaveDataReceived -= SetDropdown;
            
            _settingsView.Dropdown.onValueChanged.RemoveListener(SetLanguage);
        }

        private void SetLanguage(int index)
        {
            switch (index)
            {
                case 0:
                    YandexGame.SwitchLanguage("ru");
                    break;
                case 1:
                    YandexGame.SwitchLanguage("eu");
                    break;
                case 2:
                    YandexGame.SwitchLanguage("tr");
                    break;
                default:
                    YandexGame.SwitchLanguage("eu");
                    break;
            }
            
            _saving.Save();
            _saving.DataReceived();
        }

        private void SetDropdown()
        {
            _settingsView.Dropdown.value = YandexGame.savesData.language switch
            {
                "ru" => 0,
                "eu" => 1,
                "tr" => 2,
                _ => 1
            };
        }
    }
}