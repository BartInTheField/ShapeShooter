﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}