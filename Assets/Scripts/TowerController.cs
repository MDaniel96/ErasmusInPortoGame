using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public GameObject Player;
    public GameObject Grind;
    public GameObject restartPanel;
    public GameObject gameWonPanel;

    public float ScorePerLevel;
    public float YPerLevel;
    public float Speed;
    public float Counter;
    public float TowerCenterX;

    PlayerController playerScript;
    Grind grindScript;

    float counter;
    float nextLevel;
    float winScore;
    bool runAnimations = true;

    void Start()
    {
        playerScript = Player.GetComponent<PlayerController>();
        grindScript = Grind.GetComponent<Grind>();

        nextLevel = ScorePerLevel;
        counter = Counter;
        winScore = ScorePerLevel * 4;
    }

    void FixedUpdate()
    {
        if (runAnimations)
        {
            CheckNextLevel();
            AnimateYAtNextLevel();
            MoveTowerToCenterAtLastLevel();
            GameWon();
        }
    }

    private void CheckNextLevel()
    {
        if (playerScript.GetTopScore() > nextLevel)
        {
            nextLevel += ScorePerLevel;
            counter = 0;
            grindScript.IncreaseLevel();
        }
    }

    private void AnimateYAtNextLevel()
    {
        if (counter != Counter)
        {
            Vector2 endPosition = new Vector2(transform.position.x, transform.position.y - YPerLevel);
            transform.position = Vector2.MoveTowards(transform.position, endPosition, Speed * Time.deltaTime);
            counter++;
        }
    }

    private void MoveTowerToCenterAtLastLevel()
    {
        if (playerScript.GetTopScore() > winScore - ScorePerLevel)
        {
            Vector2 endPosition = new Vector2(TowerCenterX, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, endPosition, Speed / 3 * Time.deltaTime);
        }
    }

    private void GameWon()
    {
        if (playerScript.GetTopScore() > winScore)
        {
            restartPanel.SetActive(true);
            gameWonPanel.SetActive(true);
            runAnimations = false;
            playerScript.PauseGame();
        }
    }

    public float GetScorePerLevel()
    {
        return ScorePerLevel;
    }
}
