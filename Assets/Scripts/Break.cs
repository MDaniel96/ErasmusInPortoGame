using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    Animator animator;
    Rigidbody2D body;

    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    /* If someone hits it, it breaks */
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Rigidbody2D player = collider.gameObject.GetComponent<Rigidbody2D>();
            if (player.velocity.y <= 0)
            {
                animator.SetTrigger("BreakTrigger");
                body.bodyType = RigidbodyType2D.Dynamic;
            }
        }

        if (collider.gameObject.tag == "Bullet")
        {
            animator.SetTrigger("BreakTrigger");
            body.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
