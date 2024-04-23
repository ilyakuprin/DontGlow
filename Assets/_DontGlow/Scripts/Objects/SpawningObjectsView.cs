using UnityEngine;

namespace _DontGlow.Scripts.Objects
{
    public class SpawningObjectsView : MonoBehaviour
    {
        [field: SerializeField] public ObjectsView Objects1 { get; private set; }
        [field: SerializeField] public ObjectsView Objects2 { get; private set; }
        [field: SerializeField] public GameObject Key { get; private set; }
        
        [SerializeField] private Transform[] _poolsSpawn;
        [SerializeField] private GameObject[] _traps;

        public int LengthPools => _poolsSpawn.Length;
        public int LengthTrap => _traps.Length;
        
        public Transform GetPool(int index)
            => _poolsSpawn[index];
        
        public GameObject GetTrap(int index)
            => _traps[index];
    }
}
