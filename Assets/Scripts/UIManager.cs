using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject GameOverUI;
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI scoreValueText;

    public TextMeshProUGUI SetPlayerScore
    {
        get { return scoreValueText; }
        set { scoreValueText = value; }
    }

    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void GameOver(int playerScore, int playerHighScore)
    {
        GameOverUI.SetActive(true);
        finalScoreText.text = "Score : " + playerScore;
        highScoreText.text = "Highscore : " + playerHighScore;
    }

    public void RestartGame()
    {

    }

    public void NavigateMainMenu()
    {

    }
}
