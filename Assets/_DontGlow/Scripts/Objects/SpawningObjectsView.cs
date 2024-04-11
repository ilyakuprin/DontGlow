using UnityEngine;

namespace _DontGlow.Scripts.Objects
{
    public class SpawningObjectsView : MonoBehaviour
    {
        [field: SerializeField] public ObjectsView Objects1 { get; private set; }
        [field: SerializeField] public ObjectsView Objects2 { get; private set; }
        [field: SerializeField] public GameObject Key { get; private set; }
        
        [SerializeField] private Transform[] _poolsSpawn;

        public int LengthPools => _poolsSpawn.Length;
        
        public Transform GetPool(int index)
            => _poolsSpawn[index];
    }
}
