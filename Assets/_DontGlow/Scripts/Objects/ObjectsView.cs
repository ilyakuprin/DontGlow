using UnityEngine;

namespace _DontGlow.Scripts.Objects
{
    public class ObjectsView : MonoBehaviour
    {
        [field: SerializeField] public SpriteRenderer Note { get; private set; }
        [field: SerializeField] public GameObject Battery { get; private set; }
        [field: SerializeField] public GameObject Junk { get; private set; }
    }
}