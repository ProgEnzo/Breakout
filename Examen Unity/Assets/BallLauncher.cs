using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] private KeyCode launchKey = KeyCode.Space;
    public Transform ballTransform;

    private void Update()
    {
        if (Input.GetKeyDown(launchKey))
        {
            if (ballTransform != null)
            {
                ballTransform.GetComponent<Rigidbody>().isKinematic = false;
                
                ballTransform.parent = null;
                ballTransform = null;
            }
        }
    }
}
