using UnityEngine;

public class Grind : MonoBehaviour
{
    public GameObject Player;
    public GameObject NormalPlatform;
    public GameObject SpringPlatform;
    public GameObject BreakPlatform;
    public GameObject Hole;
    public GameObject Enemy;

    public int Level = 8;
    public int FixPrefabsOnTheScreen = 7;

    public float MinX;
    public float MaxX;

    void Start()
    {

    }

    void Update()
    {

    }

    private float SetYPositionByPlayerAndLevel()
    {
        return Player.transform.position.y + (Level + Random.Range(0.2f, 1.0f));
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

    /* Creating a new platform when old one is destroyed */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);

        if (collision.gameObject.name.StartsWith("Platform") 
            || collision.gameObject.name.StartsWith("Spring"))
        {
            if (Random.Range(1, 8) == 1)
            {
                CreateSpringPlatform();
            }
            else
            {
                CreateNormalPlatform();
            }
        }

        if (Random.Range(1, 5) == 1)
        {
            CreateBreakPlatform();
        }

        if (Random.Range(1, 30) == 1)
        {
            CreateHole();
        }

        if (Random.Range(1, 15) == 1)
        {
            CreateEnemy();
        }
    }
}
