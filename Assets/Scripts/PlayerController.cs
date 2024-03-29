﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float maxHp;
    public float hp;
    public bool isDead;
    public bool hasWon;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    private Vector3 mousePosition;
    public Transform target;

    public bool inShop;
    public GameObject winText;
    public GameObject bounty;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        inShop = false;
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        
        if (hp <= 0)
        {
            rb.velocity = new Vector2(0, 0);
            isDead = true;
            if (hp < 0)
            {
                hp = 0;
            }
        }

        if (hp > maxHp)
        {
            hp = maxHp;
        }

        if (bounty == null)
        {
            hasWon = true;
            winText.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        if (isDead == false)
        {
            Move();
            Aim();
        }
    }

    void ProcessInputs()
    {
        //Movement Inputs
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isDead || hasWon)
            {
                SceneManager.LoadScene("Level");
            }
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }

    void Aim()
    {
        Vector2 direction = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        transform.up = direction;
    }
}
