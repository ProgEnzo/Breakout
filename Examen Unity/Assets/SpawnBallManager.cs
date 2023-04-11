using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBallManager : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform paddle;

    [SerializeField] private BallLauncher ballLauncher;

    private Vector3 decal;

    private void Start()
    {
        decal = transform.position - paddle.position;

        SpawnNewBallOnPaddle();
    }

    private void Update()
    {
        transform.position = paddle.position + decal;
    }

    private void SpawnNewBallOnPaddle()
    {
        Transform ballInstance = Instantiate(ballPrefab, transform.position, Quaternion.identity, transform).transform; //créer une surcharge avec "transform" pour le caster
        ballLauncher.ballTransform = ballInstance;
    }
}
