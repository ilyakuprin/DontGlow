using UnityEngine;
using UnityEngine.SceneManagement;

namespace _DontGlow.Scripts.UI.UIMenu
{
    public class LoadGameScene : MonoBehaviour
    {
        private const int MenuSceneIndex = 1;
        
        public void Load()
            => SceneManager.LoadSceneAsync(MenuSceneIndex);
    }
}