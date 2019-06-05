using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] private ProjectileButton circleButton = null;
    [SerializeField] private ProjectileButton triangleButton = null;
    [SerializeField] private ProjectileButton squareButton = null;

    private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        circleButton.OnClick += CircleClick;
        triangleButton.OnClick += TriangleClick;
        squareButton.OnClick += SquareClick;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            CircleClick();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            TriangleClick();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            SquareClick();
        }
    }

    private void CircleClick()
    {
        PlayerFire("Circle");
    }

    private void TriangleClick()
    {
        PlayerFire("Triangle");
    }

    private void SquareClick()
    {
        PlayerFire("Square");
    }

    private void PlayerFire(string shape)
    {
        player.FireProjectile(shape);
    }
}