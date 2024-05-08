using _DontGlow.Scripts.UI.HeroUi;
using UnityEngine;

namespace _DontGlow.Scripts.ScriptableObj
{
    [CreateAssetMenu(fileName = "HeroTextConfig", menuName = "Configs/HeroTextConfig")]
    public class HeroTextConfig : ScriptableObject
    {
        [field: SerializeField, Range(0.1f, 10f)] public float FadeTimeInSec { get; private set; }
        [field: SerializeField, Range(0.1f, 10f)] public float TimeStayTextInSec { get; private set; }
        
        [field: Space]
        
        [SerializeField] private HeroTextLocalization[] _heroText;
        [field: SerializeField] public HeroTextLocalization FirstText { get; private set; }
        [field: SerializeField] public HeroTextLocalization LastText { get; private set; }

        public int LengthTextWithoutFirstAnaLast => _heroText.Length;
        public int LengthAllText => LengthTextWithoutFirstAnaLast + 2;

        public HeroTextLocalization GetText(int index)
            => _heroText[index];
    }
}