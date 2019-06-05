using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour
{
    private int score = 0;

    public event Action<int> OnScoreChanged;
    public event Action OnGameOver;

    private Player player;


    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        player.OnDamaged += PlayerDamaged;
    }

    private void PlayerDamaged(int currentHealth)
    {
        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    public void EnemyHitByWrongProjectile()
    {
        GameOver();
    }

    public void EnemyHit()
    {
        score++;
        OnScoreChanged?.Invoke(score);
    }

    private void GameOver()
    {
        OnGameOver?.Invoke();
    }
}