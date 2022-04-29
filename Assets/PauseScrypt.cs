using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScrypt : MonoBehaviour
{
    [SerializeField] GameObject pauseCanvas;
    public void ContinueHandler()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    public void ExitHandler()
    {
        pauseCanvas.SetActive(false);
        SceneManager.LoadScene("Menu");
    }
}
