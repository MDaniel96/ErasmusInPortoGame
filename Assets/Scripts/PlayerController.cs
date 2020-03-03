using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    float moveInput;
    float topScore = 0.0f;
    Gyroscope gyro;

    public float minX;
    public float maxX;
    public float minY;

    public float offsetScreenEdge;

    public float speed;

    public Text scoreText;

    public GameObject restartPanel;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        gyro = Input.gyro;
        gyro.enabled = true;
    }

    void Update()
    {
        SetFaceDirection();
        SetScore();
        CheckLeavingScreen();
        CheckDeath();
    }

    void FixedUpdate()
    {
        MoveByKeys();
        //MoveByGyro();
    }

    /* Moving player using computer keys */
    private void MoveByKeys()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
    }
    
    /* Moving player using gyroscope on phone*/
    private void MoveByGyro()
    {
        moveInput = Input.acceleration.x;
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
    }

    /* If player moving upwards changing its score */
    private void SetScore()
    {
        if (rb2d.velocity.y > 0 && transform.position.y > topScore)
        {
            topScore = transform.position.y;
        }
        scoreText.text = "Score " + Mathf.Round(topScore).ToString();
    }

    /* Rotating player if it moves to the right */
    private void SetFaceDirection()
    {
        if (moveInput < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        } else if (moveInput > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    /* Moves player to other side if it leaves the screen */
    private void CheckLeavingScreen()
    {
        if (transform.position.x < minX)
        {
            Vector3 newPosition = new Vector3(maxX - offsetScreenEdge, transform.position.y, 0);
            transform.position = newPosition;
        }

        if (transform.position.x > maxX)
        {
            Vector3 newPosition = new Vector3(minX + offsetScreenEdge, transform.position.y, 0);
            transform.position = newPosition;
        }
    }

    /* If player leaves screen bottom, it dies */
    private void CheckDeath()
    {
        if (transform.position.y < minY + topScore)
        {
            restartPanel.SetActive(true);
        }
    }
}
