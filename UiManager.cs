using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UiManager : MonoBehaviour
{
    int score = 0;
    public int lives =3;

    public TMP_Text score_Text;
    public Text livesText;

    public Text scoreText; 
   

    public bool gameOver;

    public GameObject gameOverPanel;


    public Transform[] levels;
    public int currentLevelIndex = 0;

    
    public GameObject loadingPanel;


    public TMP_Text Level;


    public int numBrick;

    void Start()
    {
        numBrick = GameObject.FindGameObjectsWithTag("brick").Length; // gets total number of bricks in level
        livesText.text = "Lives: " + lives;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateLives(int change) // this function deals with updating lives and what happens when we run out
    {
        lives += change;
        // dead with no lives
        livesText.text = "Lives: " + lives;
        if(lives <= 0)
        {
            lives = 0;
            GameOver();// when we run out of lives 
        }
        
    }


    public void IncreaseScore(int count)
    {
        score += count;
        scoreText.text = "Score: " + score;
        score_Text.text = "Score: " + score;
    }

    public void UpdateBrickNum()
    {
        numBrick--;
        Debug.Log(numBrick);
        if (numBrick <= 0)
        {
            if (currentLevelIndex >= levels.Length)
            {
                GameOver();
                Debug.Log("Game Quit");
            }
            else
            {
                Level.text = "Loading Level " + (currentLevelIndex + 2);
                loadingPanel.SetActive(true);
                gameOver = true;
                UpdateLives(1);
                Invoke("LoadLevel",3f);
            }
            
        }
    }


    void LoadLevel()
    {
        
        Instantiate(levels[currentLevelIndex],Vector2.zero,Quaternion.identity);
        currentLevelIndex++;
        numBrick = GameObject.FindGameObjectsWithTag("brick").Length;
        gameOver = false;
        loadingPanel.SetActive(false);

    }

     void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
    }







  public void PlayAgain()
  {
  SceneManager.LoadScene("Arkanoid");
  }
  
  public void Quit()
 {
  Application.Quit();
  Debug.Log("Game Quit");
  }
 

}
