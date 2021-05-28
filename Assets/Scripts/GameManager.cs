using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameover = false;
    public Text scoreText;
    public GameObject gameoverUI;
    private int score = 0;

    void Start()
    {
        if (instance == null)
            instance = this;
        else
        {
            Debug.Log("2개 이상 게임 매너지 있음");
            Destroy(instance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameover && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Desert");
        }
        if (isGameover && Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        if (score < 0)
        {
            OnPlayerDead();
        }
        scoreText.text = "Score : " + score;
    }

    public void OnPlayerDead()
    {
        isGameover = true;
        gameoverUI.SetActive(true);
    }


}
