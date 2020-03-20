﻿using TMPro;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] private float gameSpeed = 1f;
    [SerializeField] private int pointsPerBlockDestroyed = 83;
    [SerializeField] public TextMeshProUGUI scoreText;

    // State variables
    [SerializeField] public int currentPlayerScore = 0;

    //
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;

        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            // Don't destroy GameStatus gameObject when we load another scene!
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = currentPlayerScore.ToString();
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentPlayerScore += pointsPerBlockDestroyed;
        scoreText.text = currentPlayerScore.ToString();
    }
}