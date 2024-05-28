using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //Canvas
    public Canvas gameOverCanvas;
    public Canvas gameClearCanvas;
    //タイマー
    public Text timerText;
    private float timeCount = 0;
    private float timeLimit = 0;

    void Start()
    {
        //General
        Time.timeScale = 1.0f;
        //Canvas
        gameOverCanvas.gameObject.SetActive(false);
        gameClearCanvas.gameObject.SetActive(false);
        //タイマー
        timeLimit = 1000f;
        timeCount = timeLimit;
    }
    void Update()
    {
        //タイマー
        timeCount -= Time.deltaTime;
        timerText.text = timeCount.ToString("f0") + "秒";
        //時間切れ
        if (timeCount < 0)
        {
            GameOver();
        }
    }
    public void RetryButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main");
    }
    public void GameOver()
    {
        //General
        Time.timeScale = 0f;
        //Canvas
        gameOverCanvas.gameObject.SetActive(true);
    }
    public void GameClear()
    {
        Time.timeScale = 0f;
        gameClearCanvas.gameObject.SetActive(true);
    }
}
