using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    float rotationSpeed;

    void Start()
    {
        rotationSpeed = Random.Range(-200, 200);
    }

    void FixedUpdate()
    {
        Rotate();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            collider.gameObject.GetComponent<EnemyController>().Die();
        }
    }

    private void Rotate()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime, Space.Self);
    }
}
