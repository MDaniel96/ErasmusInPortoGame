using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grind : MonoBehaviour
{
    public GameObject player;
    public GameObject platformPrefabs;
    public GameObject springPrefabs;
    public GameObject breakPrefabs;

    public float minX;
    public float maxX;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    /* Creating a new platform when old one is destroyed */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Random.Range(1, 7) > 1)
        {
            if (Random.Range(1, 7) > 4)
            {
                GameObject newBreak = (GameObject)Instantiate(breakPrefabs,
                     new Vector2(Random.Range(minX, maxX),
                     player.transform.position.y + (14 + Random.Range(0.2f, 1.0f))), Quaternion.identity);

            }
            GameObject newPlatform = (GameObject)Instantiate(platformPrefabs,
                                 new Vector2(Random.Range(minX, maxX),
                                 player.transform.position.y + (14 + Random.Range(0.2f, 1.0f))), Quaternion.identity);

        } else
        {
            GameObject newPlatform = (GameObject)Instantiate(springPrefabs,
                     new Vector2(Random.Range(minX, maxX),
                     player.transform.position.y + (14 + Random.Range(0.2f, 1.0f))), Quaternion.identity);

        }
        Destroy(collision.gameObject);
    }
}
