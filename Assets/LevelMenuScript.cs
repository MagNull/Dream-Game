using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuScript : MonoBehaviour
{
    public void Level1Start()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
    }
}
