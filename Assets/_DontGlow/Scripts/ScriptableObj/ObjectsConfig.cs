using _DontGlow.Scripts.Objects;
using UnityEngine;

namespace _DontGlow.Scripts.ScriptableObj
{
    [CreateAssetMenu(fileName = "ObjectsConfig", menuName = "Configs/ObjectsConfig")]
    public class ObjectsConfig : ScriptableObject
    { 
        [field: SerializeField] public ObjectsView ObjectsView { get; private set; }
        [field: SerializeField] public Sprite LastNote { get; private set; }
        [SerializeField] private Sprite[] _note;
        
        public int Length => _note.Length;
        
        public Sprite GetNote(int index) => _note[index];
    }
}