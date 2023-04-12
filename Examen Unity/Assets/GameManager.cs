using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    
    public SpawnBallManager ball { get; private set; }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        this.lives = 3;
    }
    
    /*private void ResetLevel()
    {
        this.ball.SpawnNewBallOnPaddle();
    }*/

    private void GameOver()
    {
        //SceneManager.LoadScene("GameOver");
        
        NewGame();
    }

    /*public void Miss()
    {
        this.lives--;

        if (this.lives > 0)
        {
            ResetLevel();
        }
        else
        {
            GameOver();
        }
    }*/
}
