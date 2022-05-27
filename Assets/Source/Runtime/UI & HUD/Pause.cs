using UnityEngine;

namespace Source.Runtime.UI___HUD
{
    public class Pause : MonoBehaviour
    {
        public void ChangePauseState()
        {
            gameObject.SetActive(!gameObject.activeSelf);
            Time.timeScale = gameObject.activeSelf ? 1 : 0;
        }
    }
}