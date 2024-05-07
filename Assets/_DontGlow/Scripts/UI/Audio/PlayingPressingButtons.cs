using System;
using UnityEngine;
using UnityEngine.UI;

namespace _DontGlow.Scripts.UI.Audio
{
    public class PlayingPressingButtons : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Button[] _buttons;

        private void OnEnable()
        {
            foreach (var button in _buttons)
            {
                button.onClick.AddListener(Play);
            }
        }

        private void OnDisable()
        {
            foreach (var button in _buttons)
            {
                button.onClick.RemoveListener(Play);
            }
        }

        private void Play()
            => _audioSource.Play();

        private void OnValidate()
        {
            _buttons = FindObjectsByType<Button>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        }
    }
}