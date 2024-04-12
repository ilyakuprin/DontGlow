using TMPro;
using UnityEngine;

namespace _DontGlow.Scripts.UI
{
    public class UiInGameView : MonoBehaviour
    {
        [field: SerializeField] public TextMeshProUGUI Note { get; private set; }
        [field: SerializeField] public TextMeshProUGUI Trap { get; private set; }
        [field: SerializeField] public TextMeshProUGUI Battery { get; private set; }
        [field: SerializeField] public GameObject Key { get; private set; }
    }
}