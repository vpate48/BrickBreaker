using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    int score = 0;
    public int lives = 3;

    public TMP_Text score_Text; // score text
    public TMP_Text livesText; // life text

    public Text scoreText;


    public bool gameOver; // game flag

    public GameObject gameOverPanel; // when the game is over this panel will show


    public Transform[] levels; // array that holds our levels
    public int currentLevelIndex = 0; // keeps track  of what level we are on


    public GameObject loadingPanel; // panel for when we are loading level


    public TMP_Text Level; // displays the level we are in


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
        if (lives <= 0)
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
            if (currentLevelIndex >= levels.Length) // if we have no more levels left we end the game
            {
                GameOver();
                Debug.Log("Game Quit");
            }
            else
            {
                Level.text = "Loading Level " + (currentLevelIndex + 2); // we change the loading level 
                loadingPanel.SetActive(true); // we load the loading panel 
                gameOver = true;
                UpdateLives(1);
                Invoke("LoadLevel", 3f); // inputs for this function is the funtion were are using and how many seconds we want a delay for
                // we give a pause while loading the level for 3 seconds 
            }

        }
    }


    void LoadLevel() // this functions loads a new level
    {

        Instantiate(levels[currentLevelIndex], Vector2.zero, Quaternion.identity); // we load the level 
        currentLevelIndex++;// we increase our level tracker
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
