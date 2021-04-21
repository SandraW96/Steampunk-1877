using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenager : MonoBehaviour
{

    public int points = 0;
    public int redKey = 0;
    public int crystal = 0;
    public int goldenKey = 0;

    public void AddPoints(int point)
    {
        points += points;
    }

    public void AddTime(int addTime)
    {
        timeToEnd += addTime;
    }

    public void FreezTime(int freez)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", freez, 1);
    }
    void Stopper()
    {
        timeToEnd--;
        Debug.Log("Time: " + timeToEnd + "s");
        if (timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
            Time.timeScale = 0f;
            gamePaused = true;
        }
        if (endGame)
        {
            EndGame();
        }
    }
    public void PauseGame()
    {
        Debug.Log("Pause Game");
        Time.timeScale = 0f;
        gamePaused = true;
    }
    public void ResumeGame()
    {
        Debug.Log("Resume Game");
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void EndGame()
    {
        CancelInvoke("Stopper");
        if (win)
        {
            Debug.Log("You win!!!");
        }
        else
        {
            Debug.Log("You lose!!!");
        }
    }
    public static GameMenager gameMenager;
    public int timeToEnd;
    bool gamePaused = false;
    bool endGame = false;
    bool win = false;

    // Start is called before the first frame update
    void Start()
    {
        if (gameMenager == null)
        {
            gameMenager = this;
        }
        InvokeRepeating("Stopper", 2, 1);

        if (timeToEnd <= 0)
        {
            timeToEnd = 20;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
}
