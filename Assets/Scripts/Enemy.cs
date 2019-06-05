using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().ReceiveDamage();
            DestroySelf();
        }

        if (other.tag.EndsWith("Projectile"))
        {
            if (other.CompareTag(tag + "Projectile"))
            {
                gameManager.EnemyHit();
                Destroy(other.gameObject);
                DestroySelf();
            }
            else
            {
                Destroy(other.gameObject);
                gameManager.EnemyHitByWrongProjectile();
            }
        }
    }

    private void DestroySelf()
    {
        //Play dead effect
        //Play dead sound effect
        Destroy(gameObject);
    }
}