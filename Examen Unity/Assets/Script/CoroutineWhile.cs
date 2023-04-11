using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineWhile : MonoBehaviour
{
    [SerializeField] private float reloadInputTime;
    [SerializeField] private float reloadTime;
    [SerializeField] private bool reloaded;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Reload Input");

            reloadInputTime = Time.time;
            reloaded = false;
            Debug.Log("reloadedInput");
            Debug.Log("reloaded = " + reloaded);
        }

        if (Time.time > reloadInputTime + reloadTime)
        {
            reloaded = true;
            Debug.Log("reloaded = " + reloaded);
        }
    }
}
