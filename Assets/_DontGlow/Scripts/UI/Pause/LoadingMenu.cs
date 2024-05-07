using System;
using UnityEngine.SceneManagement;
using Zenject;

namespace _DontGlow.Scripts.UI.Pause
{
    public class LoadingMenu : IInitializable, IDisposable
    {
        private const int MenuSceneIndex = 0;
        
        private readonly UiPauseView _uiPauseView;

        public LoadingMenu(UiPauseView uiPauseView)
        {
            _uiPauseView = uiPauseView;
        }

        public void Initialize()
        {
            _uiPauseView.DefeatGoMenu.onClick.AddListener(Load);
            _uiPauseView.VictoryGoMenu.onClick.AddListener(Load);
        }

        public void Dispose()
        {
            _uiPauseView.DefeatGoMenu.onClick.RemoveListener(Load);
            _uiPauseView.VictoryGoMenu.onClick.RemoveListener(Load);
        }

        private static void Load()
            => SceneManager.LoadSceneAsync(MenuSceneIndex);
    }
}