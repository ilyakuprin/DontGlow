using System;
using _DontGlow.Scripts.Pause;
using Zenject;

namespace _DontGlow.Scripts.UI.Pause
{
    public class ShowingSettings : IInitializable, IDisposable
    {
        private readonly SettingsView _settingsView;
        private readonly SettingPause _settingPause;
        
        public ShowingSettings(SettingsView settingsView,
                               SettingPause settingPause)
        {
            _settingsView = settingsView;
            _settingPause = settingPause;
        }
        
        public void Initialize()
        {
            _settingsView.Settings.onClick.AddListener(Show);
            _settingsView.Close.onClick.AddListener(UnShow);
        }

        public void Dispose()
        {
            _settingsView.Settings.onClick.RemoveListener(Show);
            _settingsView.Close.onClick.RemoveListener(UnShow);
        }

        private void Show()
        {
            _settingPause.Pause();
            _settingsView.SettingsCanvas.gameObject.SetActive(true);
        }

        private void UnShow()
        {
            _settingPause.UnPause();
            _settingsView.SettingsCanvas.gameObject.SetActive(false);
        }
    }
}