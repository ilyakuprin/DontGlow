using UnityEngine;
using UnityEngine.UI;

namespace _DontGlow.Scripts.UI.Pause
{
    public class SettingsView : MonoBehaviour
    {
        [field: SerializeField] public Canvas SettingsCanvas { get; private set; }
        [field: SerializeField] public Button Settings { get; private set; }
        [field: SerializeField] public Button Close { get; private set; }
        [field: SerializeField] public Button GoToMenu { get; private set; }
    }
}