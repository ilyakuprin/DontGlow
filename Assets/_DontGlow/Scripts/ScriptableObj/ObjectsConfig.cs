using UnityEngine;

namespace _DontGlow.Scripts.ScriptableObj
{
    [CreateAssetMenu(fileName = "ObjectsConfig", menuName = "Configs/ObjectsConfig")]
    public class ObjectsConfig : ScriptableObject
    { 
        [field: SerializeField] public Sprite LastNote { get; private set; }
        
        [SerializeField] private Sprite[] _notes;

        public int LengthNotesWithoutFinal => _notes.Length;
        public int LengthNotesWithFinal => _notes.Length + 1;
        
        public Sprite GetNote(int index)
            => _notes[index];
    }
}