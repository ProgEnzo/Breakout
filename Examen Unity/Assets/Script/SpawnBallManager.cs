using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBallManager : MonoBehaviour
{
    public static SpawnBallManager instance;
    
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform paddle;

    [SerializeField] private BallLauncher ballLauncher;

    private Vector3 decal;

    public int lives = 4;
    private bool isDead = false;
    
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
    }

    private void Start()
    {
        decal = transform.position - paddle.position;

        SpawnNewBallOnPaddle();
    }

    private void Update()
    {
        EndGame();
        transform.position = paddle.position + decal;
    }

    public void SpawnNewBallOnPaddle()
    {
        if (lives > 0)
        {
            LoseLife();
            Transform ballInstance = Instantiate(ballPrefab, transform.position, Quaternion.identity, transform).transform; //créer une surcharge avec "transform" pour le caster
            ballLauncher.ballTransform = ballInstance;
        }
        else if (lives == 0)
        {
            isDead = true;
        }
    }

    private void LoseLife()
    {
        lives -= 1;
        Debug.Log("lifeLosed");
    }

    private void EndGame()
    {
        if (isDead == true)
        {
            UiAnimGameOver.instance.OpenMenu();
        }
    }

}
