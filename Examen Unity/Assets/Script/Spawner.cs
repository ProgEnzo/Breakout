using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject brick;

    [SerializeField] private List<Color> colors;

    private void Start()
    {
        InstantiateBricks();
    }

    private void InstantiateBricks()
    {
        StartCoroutine(JoliePourInstancier());
    }

    private IEnumerator JoliePourInstancier()
    {
        for (int i = 0; i < 7; i += 2)
        {
            for (int j = 0; j < 22; j += 3)
            {
                yield return new WaitForSeconds(0.1f);
                GameObject _brick = Instantiate(brick, new Vector3(j-10.5f, i-0.5f, 0), quaternion.identity);
                _brick.GetComponent<MeshRenderer>().material.color = colors[UnityEngine.Random.Range(0, colors.Count)];
            }
        }
    }
}
