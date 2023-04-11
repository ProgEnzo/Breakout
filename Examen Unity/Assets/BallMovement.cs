using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    [SerializeField] private Rigidbody rb;
    [SerializeField] Vector3 dir = Vector3.up;

    private void FixedUpdate()
    {
        rb.velocity = dir * speed * Time.deltaTime;
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.transform.GetComponent<PaddleMover>() != null)
        {
            PaddleBounce(other.transform, other.contacts[0].point);
        }
        else
        {
            Debug.DrawRay(other.contacts[0].point, other.contacts[0].normal, Color.yellow, 0.25f);

            Vector3 newDirection = Vector3.Reflect(dir, other.contacts[0].normal);
            newDirection.z = 0;

            float hypotenuse = (newDirection.normalized + other.contacts[0].normal).magnitude;

            if (hypotenuse > Mathf.Sqrt(2))
            {
                dir = newDirection;
                Debug.DrawRay(other.contacts[0].point, dir, Color.red, 10);
            }
            else
            {
                Debug.DrawRay(other.contacts[0].point, dir, Color.magenta, 10);
            }
        }
    }

    private void PaddleBounce(Transform paddle, Vector3 point)
    {
        float localPosX = paddle.InverseTransformPoint(point).x;
        float lerpPercent = Mathf.Clamp(localPosX + 0.5f, 0, 1);
        float angle = Mathf.Lerp(-75, 75, lerpPercent);

        dir = new Vector3(
            Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle), 0);
    }
}
