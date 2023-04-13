using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avion : MonoBehaviour
{
    public static Avion instance;
    
    [SerializeField] public Transform[] targets;
    [SerializeField] public int index;
    [SerializeField] public float speed;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }
    
    public IEnumerator AvionPlanage(Transform target)
    {
        while (Vector3.Distance(transform.position, target.position) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);

            yield return null;
        }

        if (index + 1 < targets.Length)
        {
            index++;
        }
        else
        {
            index = 0;
        }

        StartCoroutine(AvionPlanage(targets[index]));
    }
}
