using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            StartCoroutine(BounceBeforeFx());
        }
    }

    private IEnumerator BounceBeforeFx()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
