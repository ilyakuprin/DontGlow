using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _DontGlow.Scripts.Inputting
{
    public class JoystickHandler : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private RectTransform _rectangleTouchZone;
        [SerializeField] private RectTransform[] _touchZone;
        [SerializeField] private RectTransform _joystickBackground;
        [SerializeField] private Image _joystick;

        private Vector2 _joystickCreationStartPosition;
        private Vector2 _inputVector;

        public Vector2 GetInputVector => _inputVector;
        
        private void Start()
        {
            SetActive(false);
            _joystickCreationStartPosition = _joystickBackground.anchoredPosition;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickBackground,
                                                                        eventData.position,
                                                                        null,
                                                                        out var joystickPosition))
                return;

            var sizeDelta = _joystickBackground.sizeDelta;
            var sizeDeltaX = sizeDelta.x;
            var sizeDeltaY = sizeDelta.y;
            
            joystickPosition.x = joystickPosition.x * 2 / sizeDeltaX;
            joystickPosition.y = joystickPosition.y * 2 / sizeDeltaY;

            _inputVector = new Vector2(joystickPosition.x, joystickPosition.y);
            
            if (_inputVector.magnitude > 1f)
            {
                _inputVector = _inputVector.normalized;
            }

            _joystick.rectTransform.anchoredPosition = new Vector2(_inputVector.x * (sizeDeltaX / 2),
                                                                   _inputVector.y * (sizeDeltaY / 2));
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(_rectangleTouchZone,
                                                                        eventData.position,
                                                                        null,
                                                                        out var positionClick))
                return;
            
            SetActive(true);
            
            _joystickBackground.anchoredPosition = new Vector2(positionClick.x, positionClick.y);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            SetActive(false);

            _joystickBackground.anchoredPosition = _joystickCreationStartPosition;

            _inputVector = Vector2.zero;
            _joystick.rectTransform.anchoredPosition = Vector2.zero;
        }
        
        private void SetActive(bool value)
            => _joystickBackground.gameObject.SetActive(value);
    }
}
