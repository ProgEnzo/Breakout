using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public int lives = 3;
    
    public SpawnBallManager ball { get; private set; }
    

    private void Awake()
    {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(this);
            }
            
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

    private void GameOver()
    {
        NewGame();
    }

    public void Win()
    {
        if (Spawner.instance.bricksInGame.Count <= 0)
        {
            UiAnimWin.instance.OpenMenu();
        }
    }
}
