using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace _DontGlow.Scripts.UI.Sound
{
    public class SettingsView : MonoBehaviour
    {
        [field: SerializeField] public AudioMixer Mixer;
        [field: SerializeField] public Slider SliderEffects;
        [field: SerializeField] public Slider SliderMusic;
        [field: SerializeField] public TMP_Dropdown Dropdown;
    }
}