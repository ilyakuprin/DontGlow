using System;
using _DontGlow.Scripts.UI.Pause;
using UnityEngine.SceneManagement;
using Zenject;

namespace _DontGlow.Scripts.UI.GameStatus
{
    public class LoadingMenu : IInitializable, IDisposable
    {
        private const int MenuSceneIndex = 0;
        
        private readonly UiPauseView _uiPauseView;
        private readonly SettingsView _settingsView;

        public LoadingMenu(UiPauseView uiPauseView,
                           SettingsView settingsView)
        {
            _uiPauseView = uiPauseView;
            _settingsView = settingsView;
        }

        public void Initialize()
        {
            _uiPauseView.DefeatGoMenu.onClick.AddListener(Load);
            _uiPauseView.VictoryGoMenu.onClick.AddListener(Load);
            _settingsView.GoToMenu.onClick.AddListener(Load);
        }

        public void Dispose()
        {
            _uiPauseView.DefeatGoMenu.onClick.RemoveListener(Load);
            _uiPauseView.VictoryGoMenu.onClick.RemoveListener(Load);
            _settingsView.GoToMenu.onClick.RemoveListener(Load);
        }

        private static void Load()
            => SceneManager.LoadSceneAsync(MenuSceneIndex);
    }
}