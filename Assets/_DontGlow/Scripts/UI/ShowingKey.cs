using System;
using Zenject;

namespace _DontGlow.Scripts.UI
{
    public class ShowingKey : IInitializable, IDisposable
    {
        private readonly ShowingCountNote _showingCountNote;
        private readonly UiInGameView _uiInGameView;

        public ShowingKey(ShowingCountNote showingCountNote,
                          UiInGameView uiInGameView)
        {
            _showingCountNote = showingCountNote;
            _uiInGameView = uiInGameView;
        }

        public void Initialize()
            => _showingCountNote.LastNodeTaken += Show;

        public void Dispose()
            => _showingCountNote.LastNodeTaken -= Show;

        private void Show()
            => _uiInGameView.Key.SetActive(true);
    }
}