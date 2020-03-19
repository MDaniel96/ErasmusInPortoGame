using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    float moveInput;
    float topScore = 0.0f;
    Gyroscope gyro;
    TowerController towerScript;
    BeerBarController beerBarScript;
    float scorePerLevel;
    float maxBulletNumber;

    public float minX;
    public float maxX;
    public float minY;

    public float offsetScreenEdge;

    public float speed;

    public Text scoreText;

    public GameObject restartPanel;

    public GameObject Bullet;
    public float BulletForce;

    public Camera cam;

    public GameObject Tower;

    public GameObject BeerBar;

    public float BulletNumber;
    public float BulletReloadSpeed;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        gyro = Input.gyro;
        gyro.enabled = true;
        towerScript = Tower.GetComponent<TowerController>();
        beerBarScript = BeerBar.GetComponent<BeerBarController>();
        scorePerLevel = towerScript.GetScorePerLevel();

        cam = GameObject.Find("Main Camera").GetComponent<Camera>();

        //scoreText.transform.position = new Vector2(cam.orthographicSize * Screen.width / Screen.height, cam.orthographicSize - 0.5f);
    }

    void Update()
    {
        SetFaceDirection();
        //SetScore();
        SetLevel();
        CheckLeavingScreen();
        CheckDeath();
        DetectClick();
        RealoadBullets();
    }

    void FixedUpdate()
    {
        //MoveByKeys();
        MoveByGyro();
    }

    /* Moving player using computer keys */
    private void MoveByKeys()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
    }

    /* Moving player using gyroscope on phone*/
    private void MoveByGyro()
    {
        moveInput = Input.acceleration.x;
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
    }

    private void DetectClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray clickDirection = Camera.main.ScreenPointToRay(mousePosition);
            ShootBullet(clickDirection);
        }
    }

    /* Creating and shooting bullet to given direction */
    private void ShootBullet(Ray clickDirection)
    {
        float barSize = beerBarScript.GetSize();
        if (barSize >= 1 / BulletNumber)
        {
            beerBarScript.SetSize(barSize - 1 / BulletNumber);
            GameObject newBullet = Instantiate(Bullet, transform.position, Quaternion.identity);
            Rigidbody2D bullettRb2D = newBullet.gameObject.GetComponent<Rigidbody2D>();
            bullettRb2D.AddForce(clickDirection.direction * BulletForce);
        }
    }

    private void RealoadBullets()
    {
        float barSize = beerBarScript.GetSize();
        if (barSize < 1)
        {
            beerBarScript.SetSize(barSize + BulletReloadSpeed);
        }

        if (barSize >= 1 / BulletNumber)
        {
            beerBarScript.SetDefaultColor();
        } else
        {
            beerBarScript.SetEmptyColor();
        }
    }

    /* If player moving upwards changing its score */
    private void SetScore()
    {
        if (rb2d.velocity.y > 0 && transform.position.y > topScore)
        {
            topScore = transform.position.y;
        }
        scoreText.text = "Score " + Mathf.Round(topScore).ToString();
    }

    /* If player moving setting its level according to its score */
    private void SetLevel()
    {
        if (rb2d.velocity.y > 0 && transform.position.y > topScore)
        {
            topScore = transform.position.y;
        }

        if (topScore > 0 && topScore < scorePerLevel)
        {
            scoreText.text = "Level 1: Arriving to Porto";
        } else if (topScore > scorePerLevel && topScore < scorePerLevel * 2)
        {
            scoreText.text = "Level 2: Going to Parties";
        } else if (topScore > scorePerLevel * 2 && topScore < scorePerLevel * 3)
        {
            scoreText.text = "Level 3: Study at University";
        } else if (topScore > scorePerLevel * 3 && topScore < scorePerLevel * 4)
        {
            scoreText.text = "Level 4: Parties + University";
        }
        
    }

    /* Rotating player if it moves to the right */
    private void SetFaceDirection()
    {
        if (moveInput > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        } else if (moveInput < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    /* Moves player to other side if it leaves the screen */
    private void CheckLeavingScreen()
    {
        if (transform.position.x < minX)
        {
            Vector3 newPosition = new Vector3(maxX - offsetScreenEdge, transform.position.y, 0);
            transform.position = newPosition;
        }

        if (transform.position.x > maxX)
        {
            Vector3 newPosition = new Vector3(minX + offsetScreenEdge, transform.position.y, 0);
            transform.position = newPosition;
        }
    }

    /* If player leaves screen bottom, it dies */
    private void CheckDeath()
    {
        if (transform.position.y < minY + topScore)
        {
            BeerBar.SetActive(false);
            restartPanel.SetActive(true);
        }
    }

    public float GetTopScore()
    {
        return topScore;
    }

    public void PauseGame()
    {
        rb2d.isKinematic = true;
    }
}
