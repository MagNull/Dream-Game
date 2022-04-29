using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void StartLevels()
    {
        SceneManager.LoadScene("Levels");
        Time.timeScale = 1;
    }

    public void OpenSettingsScene()
    {
        SceneManager.LoadScene("Settings");
    }

    public void ExitHandler()
    {
        Application.Quit();
    }

    public void LoadSceneByName(string previousScene)
    {
        SceneManager.LoadScene(previousScene);
    }

    public void LoadSceneByNumber(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void LoadLevelByNumber(int levelNumber)
    {
        SceneManager.LoadScene("Level" + levelNumber);
    }
}
