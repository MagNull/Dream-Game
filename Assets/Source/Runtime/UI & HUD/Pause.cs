using UnityEngine;

namespace Source.Runtime.UI___HUD
{
    public class Pause : MonoBehaviour
    {
        public void ChangePauseState()
        {
            gameObject.SetActive(!gameObject.activeSelf); //Пока так, потом можно сделатб плавно.
            Time.timeScale = gameObject.activeSelf ? 1 : 0;
        }
    }
}