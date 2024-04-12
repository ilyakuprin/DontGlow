using UnityEngine;

namespace _DontGlow.Scripts.ScriptableObj
{
    [CreateAssetMenu(fileName = "FlashlightConfig", menuName = "Configs/FlashlightConfig")]
    public class FlashlightConfig : ScriptableObject
    {
        public const int CountDivision = 7;

        [field: SerializeField, Range(1f, 50f)]
        public float TimeOneDivisionSec { get; private set; }

        [field: SerializeField] public Sprite Off { get; private set; }
        [field: SerializeField] public Sprite On { get; private set; }
    }
}
