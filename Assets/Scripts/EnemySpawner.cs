using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float secondsBetweenSpawn = 2f;
    [SerializeField] private GameObject[] enemies = null;

    private GameManager gameManager;
    private bool gameOver = false;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        gameManager.OnGameOver += GameOver;
        StartCoroutine(StartSpawing());
    }

    private void GameOver()
    {
        gameOver = true;
    }

    IEnumerator StartSpawing()
    {
        int random = Random.Range(0, enemies.Length);
        GameObject enemy = enemies[random];
        Instantiate(enemy, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(secondsBetweenSpawn);

        if (!gameOver)
        {
            StartCoroutine(StartSpawing());
        }
    }
}