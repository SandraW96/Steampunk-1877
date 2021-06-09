using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenager : MonoBehaviour
{
    public Text timetext;
    public Text goldKeyText;
    public Text redKeyText;
    public Text greenKeyText;
    public Text crystalText;
    public Image snowFlake;

    public GameObject infoPanel;
    public Text paused;
    public Text reloadInfo;
    public Text useInfo;

    public int points = 0;
    public int redKey = 0;
    public int crystal = 0;
    public int goldenKey = 0;

    AudioSource audioSource;
    public AudioClip resumeClip;
    public AudioClip pauseClip;
    public AudioClip winClip;
    public AudioClip loseClip;

    public MusicScript musicScript;

    public void AddPoints(int point)
    {
        points += point;
        crystalText.text = points.ToString();
    }

    public void AddTime(int addTime)
    {
        timeToEnd += addTime;
        timetext.text = timeToEnd.ToString();
    }

    public void FreezTime(int freez)
    {
        CancelInvoke("Stopper");
        snowFlake.enabled = true;
        InvokeRepeating("Stopper", freez, 1);
    }

    public void AddKey(KeyColor color)
    {
        if (color == KeyColor.Gold)
        {
            goldenKey++;
            goldKeyText.text = goldenKey.ToString();
        }
        else if (color == KeyColor.Crystal)
        {
            crystal++;

        }
        else if (color == KeyColor.Red)
        {
            redKey++;
            redKeyText.text = redKey.ToString();
        }
    }
    void Stopper()
    {
        timeToEnd--;
        timetext.text = timeToEnd.ToString();
        snowFlake.enabled = false;

        //Debug.Log("Time: " + timeToEnd + "s");
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
        if (timeToEnd < 20 && !lessTime)
        {
            LessTimeOn();
            lessTime = true;
        }
        if (timeToEnd> 20 && lessTime)
        {
            LessTimeOff();
            lessTime = false;
        }
    }
    public void PauseGame()
    {
        infoPanel.SetActive(true);
        //Debug.Log("Pause Game");
        Time.timeScale = 0f;
        gamePaused = true;
        PlayClip(pauseClip);
        musicScript.OnPauseGame();
    }
    public void ResumeGame()
    {
        //Debug.Log("Resume Game");
        infoPanel.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
        PlayClip(resumeClip);
        musicScript.OnResumeGame();
    }
    public void LessTimeOn()
    {
        musicScript.PitchThis(1.58f);
    }
    public void LessTimeOff()
    {
        musicScript.PitchThis(1f);
    }

    public void EndGame()
    {
        CancelInvoke("Stopper");
        infoPanel.SetActive(true);

        if (win)
        {
            //Debug.Log("You win!!!");
            paused.text = "Win!!";
            reloadInfo.text = "Reload? Y/N";
            PlayClip(winClip);
        }
        else
        {
            paused.text = "Loser!";
            reloadInfo.text = "Reload? Y/N";
            //Debug.Log("You lose!!!");
            PlayClip(loseClip);
        }
    }
    public static GameMenager gameMenager;
    public int timeToEnd;
    bool gamePaused = false;
    bool endGame = false;
    bool win = false;
    bool lessTime = false;

    public void PlayClip(AudioClip playClip)
    {
        audioSource.clip = playClip;
        audioSource.Play();
    }
    public void SetUseInfo(string info)
    {
        useInfo.text = info;
    }

    public void WinGame()
    {
        win = true;
        endGame = true;
    }

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

        snowFlake.enabled = false;
        timetext.text = timeToEnd.ToString();
        infoPanel.SetActive(false);
        paused.text = "Pause";
        reloadInfo.text = " ";
        SetUseInfo("");
        LessTimeOff();

        Time.timeScale = 1f;


        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Stopper", 2, 1);
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

        if (endGame)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                SceneManager.LoadScene(0);
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                Application.Quit();
            }
        }
    }
}
