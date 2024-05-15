using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace _DontGlow.Scripts.UI.LoadingScreen
{
    public class PointsAnimShowing : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private TextMeshProUGUI _text;
        
        private CancellationToken _ct;
        private int _counter;
        
        private void Start()
        {
            _ct = this.GetCancellationTokenOnDestroy();
            Show().Forget();
        }


        private async UniTask Show()
        {
            while (_canvas.gameObject.activeInHierarchy)
            {
                switch (_counter)
                {
                    case 0:
                        _text.text = ".";
                        _counter++;
                        break;
                    case 1:
                        _text.text = "..";
                        _counter++;
                        break;
                    default:
                        _text.text = "...";
                        _counter = 0;
                        break;
                }

                await UniTask.WaitForSeconds(0.5f, cancellationToken: _ct);
            }
        }
    }
}