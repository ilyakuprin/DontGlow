using UnityEngine;
using UnityEngine.UI;

namespace _DontGlow.Scripts.UI.GameStatus
{
    public class UiPauseView : MonoBehaviour
    {
        public const float FadeTime = 1f;
        public const float TargetFade = 1f;
        
        [field: SerializeField] public Canvas Defeat { get; private set; }
        [field: SerializeField] public Button DefeatGoMenu { get; private set; }
        [SerializeField] private Graphic[] _graphicDefeat;
        
        [field: Space]
        
        [field: SerializeField] public Canvas Victory { get; private set; }
        [field: SerializeField] public Button VictoryGoMenu { get; private set; }
        [SerializeField] private Graphic[] _graphicVictory;

        public int LengthGraphicDefeat => _graphicDefeat.Length;
        public int LengthGraphicVictory => _graphicVictory.Length;
        
        public Graphic GetGraphicDefeat(int index)
            => _graphicDefeat[index];
        
        public Graphic GetGraphicVictory(int index)
            => _graphicVictory[index];
    }
}