using _DontGlow.Scripts.ScriptableObj;
using UnityEngine;
using Zenject;

namespace _DontGlow.Scripts.Objects
{
    public class CreatingSequenceNotes : IInitializable
    {
        private readonly ObjectsConfig _objectsConfig;

        private Sprite[] _notes;
        
        public CreatingSequenceNotes(ObjectsConfig objectsConfig)
        {
            _objectsConfig = objectsConfig;
        }

        public int Length => _notes.Length;
        
        public Sprite GetNote(int index)
            => _notes[index];

        public void Initialize()
        {
            FillNotes();
            MixNotes();
        }
        
        private void FillNotes()
        {
            _notes = new Sprite[_objectsConfig.LengthNotesWithFinal];

            for (var i = 0; i < _notes.Length - 1; i++)
            {
                _notes[i] = _objectsConfig.GetNote(i);
            }
            
            _notes[^1] = _objectsConfig.LastNote;
        }

        private void MixNotes()
        {
            for (var i = _objectsConfig.LengthNotesWithoutFinal - 1; i > 0; i--)
            {
                var randomIndex = Random.Range(0, i + 1);
                (_notes[randomIndex], _notes[i]) = (_notes[i], _notes[randomIndex]);
            }
        }
    }
}