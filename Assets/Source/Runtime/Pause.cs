using UnityEngine;

namespace Source.Runtime
{
    public class Pause : MonoBehaviour
    {
        public void ChangePauseState()
        {
            gameObject.SetActive(!gameObject.activeSelf); //Пока так, потом можно сделать плавно
            Time.timeScale = gameObject.activeSelf ? 0 : 1;
        }
    }
}