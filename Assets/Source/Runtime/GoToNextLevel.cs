using System;
using Source.Slime_Components;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour
{
    [SerializeField] 
    private int _nextLevelIndex;

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(_nextLevelIndex);
    }
}