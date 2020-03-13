using UnityEngine;

public class Grind : MonoBehaviour
{
    public GameObject Player;
    public GameObject NormalPlatform;
    public GameObject SpringPlatform;
    public GameObject BreakPlatform;
    public GameObject Hole;
    public GameObject Enemy;

    public float MinX;
    public float MaxX;

    int level = 1;

    void Start()
    {

    }

    void Update()
    {

    }

    private float SetYPositionByPlayerAndLevel()
    {
        return Player.transform.position.y + 8 + Random.Range(0.2f, 1.0f);
    }

    private void CreateNormalPlatform()
    {
        GameObject newPlatform = Instantiate(NormalPlatform,
                                 new Vector2(Random.Range(MinX, MaxX),
                                 SetYPositionByPlayerAndLevel()), Quaternion.identity);
    }

    private void CreateSpringPlatform()
    {
        GameObject newPlatform = Instantiate(SpringPlatform,
                     new Vector2(Random.Range(MinX, MaxX),
                     SetYPositionByPlayerAndLevel()), Quaternion.identity);
    }

    private void CreateBreakPlatform()
    {
        GameObject newBreak = Instantiate(BreakPlatform,
                      new Vector2(Random.Range(MinX, MaxX),
                      SetYPositionByPlayerAndLevel()), Quaternion.identity);
    }

    private void CreateHole()
    {
        GameObject newHole = Instantiate(Hole,
              new Vector2(Random.Range(MinX, MaxX),
              SetYPositionByPlayerAndLevel()), Quaternion.identity);
    }

    private void CreateEnemy()
    {
        GameObject newHole = Instantiate(Enemy,
              new Vector2(Random.Range(MinX, MaxX),
              SetYPositionByPlayerAndLevel()), Quaternion.identity);
    }

    public void IncreaseLevel()
    {
        level++;
    }

    /* Creating a new platform when old one is destroyed */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);

        if (collision.gameObject.name.StartsWith("Platform") 
            || collision.gameObject.name.StartsWith("Spring"))
        {
            if (Random.Range(1, 12) == 1)
            {
                CreateSpringPlatform();
            }
            else
            {
                CreateNormalPlatform();
            }


            if (level == 2 || level == 4)
                if (Random.Range(1, 9) == 1)
                {
                    CreateHole();
                }

            if (level >= 3 && Random.Range(1, 8) == 1)
            {
                CreateEnemy();
            }

            if (Random.Range(1, 10) == 1)
            {
                CreateBreakPlatform();
            }
        }
        
    }
}
