using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public struct NamedProjectile
{
    public string name;
    public GameObject projectile;
}

public class Player : MonoBehaviour
{
    [SerializeField] private NamedProjectile[] projectiles = null;
    [SerializeField] private int startHealth = 3;


    public event Action<int> OnDamaged;

    private Animator animator;
    private GameManager gameManager;
    private int health;
    private bool gameOver = false;

    private void Awake()
    {
        animator = FindObjectOfType<Animator>();
        gameManager = FindObjectOfType<GameManager>();
        health = startHealth;
    }

    private void Start()
    {
        gameManager.OnGameOver += GameOver;
    }

    public void ReceiveDamage()
    {
        health--;
        animator.SetTrigger("isHit");
        AudioManager.Instance.Play("isHit");
        OnDamaged?.Invoke(health);
    }

    public void FireProjectile(string shape)
    {
        if (!gameOver)
        {
            AudioManager.Instance.Play("shoot");
            GameObject projectile = projectiles.First((namedProjectile => namedProjectile.name == shape)).projectile;
            Instantiate(projectile, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.identity);
        }
    }

    private void GameOver()
    {
        gameOver = true;
        gameObject.SetActive(false);
    }

    public int GetHealth()
    {
        return health;
    }
}