using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Coroutines : MonoBehaviour
{
    [SerializeField] private float timer = 3f;

    public IEnumerator Attends(float t)
    {
        Debug.Log("je te jure j'attend: " + Time.time);
        yield return new WaitForSeconds(t);
        timer -= t;
        Debug.Log("Timer: " + timer);
        Debug.Log("j'ai attendu: " + Time.time);

        if (timer > 0) 
            StartCoroutine(Attends(t));
        else
        {
            Debug.Log("Letsgo: ");
        }
    }
}
