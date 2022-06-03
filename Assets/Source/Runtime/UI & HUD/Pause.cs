using UnityEngine;

namespace Source.Runtime.UI___HUD
{
    public class Pause : MonoBehaviour
    {
        private InputBindings _inputBindings;

        private void Awake()
        {
            _inputBindings = FindObjectOfType<InputBindings>();
            _inputBindings.BindPause(this);
            gameObject.SetActive(false);
        }

        public void ChangePauseState()
        {
            gameObject.SetActive(!gameObject.activeSelf); //Пока так, потом можно сделатб плавно.
            Time.timeScale = gameObject.activeSelf ? 0 : 1;
        }
    }
}