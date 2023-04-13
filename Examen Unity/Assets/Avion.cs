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

    public bool isMoving;
    
    public void AvionPlanage()
    {
            if (isMoving == false)
            {
                StartCoroutine(AvionPlanage(targets[instance.index]));
            }
    }
    public IEnumerator AvionPlanage(Transform target)
    {
        isMoving = true;
        while (Vector3.Distance(transform.position, target.position) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);

            yield return null;
        }

        if (index  < targets.Length-1)
        {
            index++;
            
            StartCoroutine(AvionPlanage(targets[index]));
          
        }
        else
        {
            isMoving = false;
            index = 0;
        }

       
    }
}
