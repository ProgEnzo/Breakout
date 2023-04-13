using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            StartCoroutine(Avion.instance.AvionPlanage(Avion.instance.targets[Avion.instance.index]));
        }
    }
}
