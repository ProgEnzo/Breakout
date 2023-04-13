using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using EZCameraShake;
using Random = UnityEngine.Random;

public class Bricks : MonoBehaviour
{
    //public static Bricks instance;
    
    [SerializeField] private GameObject score;
    [SerializeField] private GameObject Fx;

    [SerializeField] private float bonusValue = 0.5f;

    [SerializeField] private GameObject bonusPrefab;

    //public CameraShake cameraShake;
    
    /*private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }*/
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Spawner.instance.bricksInGame.Remove(this.gameObject);
            GameManager.instance.Win();
            CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 1f);
            ScoreManager.Instance.IncreasedScore(transform, 100);
            Instantiate(Fx, transform.position, quaternion.identity);

            var spawnBonus = Random.Range(0, 1);
            if (spawnBonus > bonusValue)
            {
                Instantiate(bonusPrefab, transform.position, Quaternion.identity);
            }

            StartCoroutine(BounceBeforeFx());
        }
    }

    private IEnumerator BounceBeforeFx()
    {
        yield return new WaitForSeconds(0.1f); //0.1
        Destroy(gameObject);
    }

}
