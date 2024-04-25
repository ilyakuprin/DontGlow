using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

namespace _DontGlow.Scripts.UI.Game
{
    public class UiInGameView : MonoBehaviour
    {
        [field: SerializeField] public TextMeshProUGUI Note { get; private set; }
        [field: SerializeField] public TextMeshProUGUI Trap { get; private set; }
        [field: SerializeField] public TextMeshProUGUI Battery { get; private set; }
        [field: SerializeField] public GameObject Key { get; private set; }
        [field: SerializeField] public Button OnOffFlashlight { get; private set; }
        [field: SerializeField] public Image OnOffFlashlightImage { get; private set; }
        [field: SerializeField] public Button TrapButton { get; private set; }
        
        [SerializeField] private Image[] _division;

        public int LengthDivision => _division.Length;

        public Image GetDivision(int index)
            => _division[index];
    }
}