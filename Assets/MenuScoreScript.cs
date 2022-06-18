using UnityEngine;
using UnityEngine.UI;

public class MenuScoreScript : MonoBehaviour
{

    [SerializeField]
    private Sprite _activeSprite;

    [SerializeField]
    private Sprite _inActiveSprite;

    [SerializeField] private string currentLevel;

    private Image[] _scoreIconsChilds;

    void Awake()
    {
        _scoreIconsChilds = transform.GetComponentsInChildren<Image>();
        print("OnStart");
        var currentScore = PlayerPrefs.GetInt(currentLevel);
        print(currentScore);
        for (var i = 0; i < _scoreIconsChilds.Length; i++)
            if (i<currentScore)
                _scoreIconsChilds[i].sprite = _activeSprite;
            else
            {
                _scoreIconsChilds[i].sprite = _inActiveSprite;
            }
    }
}
