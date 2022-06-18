using UnityEngine;
using UnityEngine.UI;

public class ActivationScoreScript : MonoBehaviour
{
    [SerializeField]
    private Sprite _activeSprite;
    [SerializeField]
    private Sprite _inActiveSprite;

    private Image[] _scoreIconsChilds;
    void Awake()
    {
        print("@@@@");
        transform.parent.gameObject.SetActive(true);
        _scoreIconsChilds = transform.GetComponentsInChildren<Image>();
        foreach (var child in _scoreIconsChilds)
        {
            child.sprite = _inActiveSprite;
        }
        transform.parent.gameObject.SetActive(false);
    }

    public void UpdateIcons(int score)
    {
        for (int i = 0; i < score; i++)
        {
            print(i);
            _scoreIconsChilds[i].sprite = _activeSprite;
        }
    }
}
