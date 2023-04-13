using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;

public class PaddleMover : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float maxLateralDistance = 10;
    [SerializeField] private KeyCode leftKey = KeyCode.LeftArrow;
    [SerializeField] private KeyCode rightKey = KeyCode.RightArrow;

    private Vector3 originalScale;
    private Vector3 scaleTo;

    private void Start()
    {
        originalScale = transform.localScale;
        scaleTo = originalScale * 1.25f;
    }

    private void Update()
    {
        if (Input.GetKey(leftKey))
        {
            transform.position -= speed * Vector3.right * Time.deltaTime;
        }
        if (Input.GetKey(rightKey))
        {
            transform.position += speed * Vector3.right * Time.deltaTime;
        }

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x,-maxLateralDistance + transform.localScale.x * 0.5f, maxLateralDistance - transform.localScale.x * 0.5f), 
            transform.position.y, 
            transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            transform.DOScale(scaleTo, 0.2f)
                .SetEase(Ease.InFlash)
                .OnComplete(() =>
                {
                    transform.DOScale(originalScale, 0.2f)
                        .SetEase(Ease.OutFlash);
                });
        }
    }
}
