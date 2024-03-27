using UnityEngine;

namespace _DontGlow.Scripts.Objects
{
    public class ObjectsView : MonoBehaviour
    {
        [field: SerializeField] public SpriteRenderer Note { get; private set; }
    }
}