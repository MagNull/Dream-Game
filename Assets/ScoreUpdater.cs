using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    public int currentScore;
    [SerializeField] private int MaxScore;

    [SerializeField] private TMP_Text Text;

    void Awake()
    {
        currentScore = 0;
        UpdateText();
    }

    public void IncreaseScore()
    {
        currentScore++;
    }

    void Update()
    {
        UpdateText();
    }

    void UpdateText()
    {
        Debug.Log(MaxScore);
        Text.text = $"Current score: {currentScore} from {MaxScore}";
    }
}
