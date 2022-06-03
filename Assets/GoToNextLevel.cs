using Source.Slime_Components;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour
{
    [SerializeField] 
    private int _nextLevelIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Slime _))
            SceneManager.LoadScene(_nextLevelIndex);
    }
}
