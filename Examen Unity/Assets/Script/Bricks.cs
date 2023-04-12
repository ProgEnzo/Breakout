using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using EZCameraShake;

public class Bricks : MonoBehaviour
{
    [SerializeField] private GameObject score;
    [SerializeField] private GameObject Fx;

    //public CameraShake cameraShake;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 1f);
            ScoreManager.Instance.IncreasedScore(transform, 100);
            Instantiate(Fx, transform.position, quaternion.identity);
            
            StartCoroutine(BounceBeforeFx());
        }
    }

    private IEnumerator BounceBeforeFx()
    {
        yield return new WaitForSeconds(0.1f); //0.1
        Destroy(gameObject);
    }

}
