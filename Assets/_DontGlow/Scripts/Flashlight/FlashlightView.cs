using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace _DontGlow.Scripts.Flashlight
{
    public class FlashlightView : MonoBehaviour
    {
        [field: SerializeField] public Light2D Flashlight { get; private set; }
        [field: SerializeField] public AudioSource Audio { get; private set; }
    }
}