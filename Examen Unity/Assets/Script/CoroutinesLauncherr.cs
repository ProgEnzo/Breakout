using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutinesLauncherr : MonoBehaviour
{
    [SerializeField] private Coroutines coroutine;

    private void Start()
    {
        StartCoroutine(coroutine.Attends(1f));
    }
}
