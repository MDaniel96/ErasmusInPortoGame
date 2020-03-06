using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public GameObject Player;
    public float ScorePerLevel;
    public float YPerLevel;
    public float Speed;

    PlayerController playerScript;
    float counter;
    float nextLevel;

    void Start()
    {
        playerScript = Player.GetComponent<PlayerController>();
        nextLevel = ScorePerLevel;
        counter = 40;
    }

    void FixedUpdate()
    {
        if (playerScript.GetTopScore() > nextLevel)
        {
            nextLevel += ScorePerLevel;
            counter = 0;
        }

        if (counter != 40)
        {
            Vector2 endPosition = new Vector2(transform.position.x, transform.position.y - YPerLevel);
            transform.position = Vector2.MoveTowards(transform.position, endPosition, Speed * Time.deltaTime);
            counter++;
        }
    }
}
