using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{

    public int playerScore;
    public Text scoreText;
    public Text userHighScore;
    public GameObject gameOverScreen;

    private int highScore;

    [ContextMenu("Increase Score")]   // for testing functionality!
    public void addScore(int scoreAdded)
    {
        playerScore = playerScore + scoreAdded;
        scoreText.text = playerScore.ToString();
    }

    public void highScoreDisplay()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        string highScoreStr;
        if (playerScore > highScore)
            highScoreStr = playerScore.ToString();
        else
            highScoreStr = highScore.ToString();

        userHighScore.text = "Your High Score = " + highScoreStr;
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        if ( playerScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
        }
        
        gameOverScreen.SetActive(true);
        highScoreDisplay();

        PlayerPrefs.Save();
    }
}
