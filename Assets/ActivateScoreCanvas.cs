using Source.Slime_Components;
using UnityEngine;

public class ActivateScoreCanvas : MonoBehaviour
{
    [SerializeField]
    private GameObject _scoreCanvas;

    [SerializeField] 
    private GameObject _scorePointsHandler;

    [SerializeField] private string _currentLevel;

    private int _curScore;
    
    void Start()
    {
        _curScore = 0;
        _scoreCanvas.SetActive(false);
    }

    public void UpdateScoreOnExit()
    {
        var scoreActivation = _scorePointsHandler.GetComponent<ActivationScoreScript>();
        _curScore++;
        scoreActivation.UpdateIcons(_curScore);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Slime _))
        {
            _scoreCanvas.SetActive(true);
            FindObjectOfType<InputBindings>().enabled = false;
        }
        PlayerPrefs.SetInt(_currentLevel, _curScore);
    }
}
