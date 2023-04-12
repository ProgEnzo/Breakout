using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public float score;

    [SerializeField] private GameObject scorePrefab;
    [SerializeField] private TextMeshProUGUI text;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
    }

    public void IncreasedScore(Transform transform, int value)
    {
        GameObject scoreInstance = Instantiate(scorePrefab, transform.position, quaternion.identity);
        scoreInstance.GetComponentInChildren<TextMeshPro>().text = value.ToString();
        
        Destroy(scoreInstance, 1);
        this.score += value;

        text.text = score.ToString();
    }
}
