using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] private KeyCode launchKey = KeyCode.Space;
    public Transform ballTransform;

    public bool isStarting;

    public void Start()
    {
        isStarting = true;
    }

    private void Update()
    {
        StartCoroutine(WaitForStart());
    }

    private IEnumerator WaitForStart()
    {
        yield return new WaitForSeconds(3f);
        
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
