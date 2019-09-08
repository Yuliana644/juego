using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { set; get; }

    private PlayerMotor motor;

    private bool isGameStarted = false;

    // puntuacion

    private float score;
    private float coins;

    // text

    public Text scoreText;
    public Text coinsText;
    public Text scoreTextTotal;
    public Text coinsTextTotal;
    public GameObject play;
    public GameObject gameOverPanel;

    public bool IsGameStarted
    {
        get
        {
            return isGameStarted;
        }
    }
    private void Awake()
    {
        Instance = this;

        motor = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>();
    }
    // Start is called before the first frame update
    void Start()
    {
        updateScores();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStarted)
        {
            score += (Time.deltaTime * 2);
            scoreText.text = score.ToString("0");
        }
    }

    public void startGame ()
    {
        isGameStarted = true;
        play.SetActive(false);
        motor.StartRun();
    }

    public void GetCollectable (int collectableAmnt)
    {
        coins++;
        score += collectableAmnt;
        updateScores();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        scoreTextTotal.text =  scoreText.text;
        coinsTextTotal.text = coinsText.text;
        coinsText.text = coins.ToString("0");
        play.SetActive(true);
    }

    public void PlayAgain ()
    {
        //iniciar el nivel de nuevo
        Invoke("LoadScene", 1f);
    }

    void LoadScene ()
    {
        SceneManager.LoadScene(0);
    }

    public void updateScores () {
        scoreText.text = score.ToString("0");
        coinsText.text = coins.ToString("0");
    }

}
