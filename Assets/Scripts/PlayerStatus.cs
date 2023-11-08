using UnityEngine;
using System.Collections;

public class PlayerStatus : EntityStats
{
    int m_playerScore;
    int m_playerHighscore;

    public int PlayerScore
    {
        get { return m_playerScore; }
        set { m_playerScore = value; }
    }

    public int PlayerHighscore
    {
        get { return m_playerHighscore; }
        set { m_playerHighscore = value; }
    }

    private void Update()
    {
        UIManager.Instance.SetPlayerScore.text = "" + m_playerScore;
        if(EntityHealth <= 0 )
        {
            PlayerDead();
        }
    }

    void PlayerDead()
    {
        m_playerHighscore = GameFunctionLibrary.Instance.CheckHighScore(m_playerScore, m_playerHighscore);

        UIManager.Instance.GameOver(m_playerScore, m_playerHighscore);
    }
}