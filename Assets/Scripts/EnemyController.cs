using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float MinX;
    public float MaxX;
    public float YRange;
    public float UpForce;
    public float GravityScale;
    public float Mass;

    public float Speed;

    Vector2 targetPosition;
    Rigidbody2D rb2d;
    bool rotate = false;

    void Start()
    {
        ResetTargetPosition();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveToTargetPosition();
        Rotate();

    }

    private void MoveToTargetPosition()
    {
        if ((Vector2)transform.position != targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                targetPosition, Speed * Time.deltaTime);
        } else
        {
            ResetTargetPosition();
        }
    }

    /* Returns a random position on X axis with a small Y range */
    private Vector2 GetRandomPosition()
    {
        float currentY = transform.position.y;
        float randomX = UnityEngine.Random.Range(MinX, MaxX);
        float randomY = UnityEngine.Random.Range(currentY-YRange, currentY+YRange);
        return new Vector2(randomX, randomY);
    }

    /* Reset target position to new random position */
    private void ResetTargetPosition()
    {
        targetPosition = GetRandomPosition();
    }

    /* Interaction with player */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody2D player = collision.gameObject.GetComponent<Rigidbody2D>();
            if (player.velocity.y <= 0)
            {
                player.AddForce(Vector3.up * UpForce);
                Die();
            }
            if (player.velocity.y > 0)
            {
                player.AddForce(Vector3.down * UpForce * 1.5f);
            }
        }
    }

    /* Enemy falls down rotating */
    private void Die()
    {
        rotate = true;
        rb2d.gravityScale = GravityScale;
        rb2d.mass = Mass;
        rb2d.bodyType = RigidbodyType2D.Dynamic;
    }

    /* Roatating around axis z */
    private void Rotate()
    {
        if (rotate)
        {
            transform.Rotate(0, 0, 600 * Time.deltaTime, Space.Self);
        }
    }
}
