using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Paddle"))
        {
            Avion.instance.AvionPlanage();
            StartCoroutine(StartPlane());
        }
    }

    private IEnumerator StartPlane()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
