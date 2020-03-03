using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleController : MonoBehaviour
{
    public float pullRadius;
    public float pullForce;

    public void FixedUpdate()
    {
        PullPlayer();
    }

    /* Pulls player in a certain radius */
    private void PullPlayer()
    {
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(transform.position, pullRadius))
        {
            if (collider.gameObject.tag == "Player")
            {
                Rigidbody2D player = collider.gameObject.GetComponent<Rigidbody2D>();
                Vector3 forceDirection = transform.position - player.transform.position;
                float strength = 1 / (forceDirection.magnitude / pullRadius);
                player.AddForce(forceDirection * pullForce * strength);
            }
        }

    }
}
