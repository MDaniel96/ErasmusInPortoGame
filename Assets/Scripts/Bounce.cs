using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    Rigidbody2D player;

    public float upForce;

    void Start()
    {

    }

    void Update()
    {
        
    }

    /* If Player moves downwards on platform it pushes it */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject.GetComponent<Rigidbody2D>();
            if (player.velocity.y <= 0)
            {
                player.AddForce(Vector3.up * upForce);
            }
        }
    }
}
