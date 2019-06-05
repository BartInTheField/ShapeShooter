using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText = null;
    [SerializeField] private TextMeshProUGUI scoreText = null;
    [SerializeField] private GameObject gameOverScreen = null;

    private GameManager gameManager;
    private Player player;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();
    }


    private void Start()
    {
        SetScore(0);
        SetHealth(player.GetHealth());

        player.OnDamaged += SetHealth;
        gameManager.OnGameOver += ShowGameOverScreen;
        gameManager.OnScoreChanged += SetScore;
    }

    private void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }

    private void SetHealth(int health)
    {
        healthText.text = health.ToString();
    }

    private void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }
}