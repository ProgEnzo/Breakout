using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using EZCameraShake;
using Random = UnityEngine.Random;

public class Bricks : MonoBehaviour
{
    [SerializeField] private GameObject score;
    [SerializeField] private GameObject Fx;

    [SerializeField] private float bonusValue = 0.01f;

    [SerializeField] private GameObject bonusPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        
        if (collision.gameObject.CompareTag("Ball"))
        {
            Spawner.instance.bricksInGame.Remove(this.gameObject);
            GameManager.instance.Win();
            CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 1f);
            ScoreManager.Instance.IncreasedScore(transform, 100);
            Instantiate(Fx, transform.position, quaternion.identity);

            StartCoroutine(WaitForBonus());
            StartCoroutine(BounceBeforeFx());
        }
    }

    private IEnumerator BounceBeforeFx()
    {
        yield return new WaitForSeconds(0.1f); //0.1
        Destroy(gameObject);
    }

    private IEnumerator WaitForBonus()
    {
        var spawnBonus = Random.Range(0f, 1f);
        if (spawnBonus < bonusValue)
        {
            Instantiate(bonusPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(10f);
        }
        
    }

}
