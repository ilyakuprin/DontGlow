using UnityEngine;

namespace _DontGlow.Scripts.MainHero
{
    public class MainHeroView : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public Transform Flashlight { get; private set; }
        [field: SerializeField] public Collider2D FullCollider { get; private set; }
        [field: SerializeField] public AudioSource MainSounds { get; private set; }
        [field: SerializeField] public AudioSource TakenObjSound { get; private set; }
        [field: SerializeField] public AudioSource ExitSound { get; private set; }
    }
}