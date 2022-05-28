using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Runtime.UI___HUD
{
    public class LevelLoading : MonoBehaviour
    {
        public void LoadLevel(int index) => SceneManager.LoadSceneAsync(index + 1);

        public void LoadMenu() => SceneManager.LoadSceneAsync(0);
        
        public void Exit() => Application.Quit();
    }
}