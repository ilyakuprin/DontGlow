using System;
using _DontGlow.Scripts.MainHero;
using _DontGlow.Scripts.Objects;
using Zenject;

namespace _DontGlow.Scripts.UI
{
    public class AddingNote : IInitializable, IDisposable
    {
        private const string Format = "{0}/{1}";

        private readonly PickingUpItems _pickingUpItems;
        private readonly UiInGameView _uiInGameView;
        private readonly CreatingSequenceNotes _creatingSequenceNotes;

        private int _counter;

        public AddingNote(PickingUpItems pickingUpItems,
                          UiInGameView uiInGameView,
                          CreatingSequenceNotes creatingSequenceNotes)
        {
            _pickingUpItems = pickingUpItems;
            _uiInGameView = uiInGameView;
            _creatingSequenceNotes = creatingSequenceNotes;
        }
        
        public void Initialize()
        {
            Show();
            
            _pickingUpItems.TakenNote += Add;
        }

        public void Dispose()
        {
            _pickingUpItems.TakenNote -= Add;
        }

        private void Add()
        {
            _counter++;
            Show();
        }

        private void Show()
        {
            _uiInGameView.Note.text = string.Format(Format, _counter, _creatingSequenceNotes.Length);
        }
    }
}