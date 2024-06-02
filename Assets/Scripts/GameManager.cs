using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //結果UI
    public Canvas gameOverCanvas;
    public Canvas gameClearCanvas;
    public Text resultText;

    //タイマー
    public Text timerText;
    private float timeCount = 0;
    public float timeLimit = 0;

    //徳テキスト
    public Text tokuText;
    private int tokuCount;
    void Start()
    {
        //General
        Time.timeScale = 1.0f;
        //Canvas
        gameOverCanvas.gameObject.SetActive(false);
        gameClearCanvas.gameObject.SetActive(false);
        //タイマー
        timeCount = timeLimit;
        //徳
        tokuText.text = "0";
        tokuCount = 0;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
        resultText.text = "残り時間：" + timeCount.ToString("f0") + "秒";
        tokuCount += (int)timeCount;
        tokuText.text = tokuCount.ToString();
    }
    public void MissionClear()
    {
        TokuGain(100);
    }
    private void TokuGain(int count)
    {
        tokuCount += count;
        tokuText.text = tokuCount.ToString("F0");
    }
}
