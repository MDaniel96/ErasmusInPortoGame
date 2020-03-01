using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
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
                animator.SetTrigger("BreakStartTrigger");
            }
        }
    }
}
