using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public void MoveToAnthMenuPanel(GameObject panelToMove)
    {
        panelToMove.SetActive(true);
        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.SetActive(false);
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
        Time.timeScale = 1;
    }
}
