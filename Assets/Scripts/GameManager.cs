using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //結果UI
    [SerializeField] private Canvas gameOverCanvas;
    [SerializeField] private Canvas gameClearCanvas;
    [SerializeField] private Text resultText;

    //タイマー
    [SerializeField] private Text timerText;
    private float timeCount = 0;
    [SerializeField] private float timeLimit = 0;

    //徳テキスト
    [SerializeField] private Text tokuText;
    public int tokuCount;
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
        UpdateTimer();

    }
    private void UpdateTimer()
    {
        //タイマー
        timeCount -= Time.deltaTime;
        timerText.text = $"{timeCount:f0}秒";
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
        AddTokuCount((int)timeCount);
    }
    public void MissionClear()
    {
        AddTokuCount(100);
    }
    private void AddTokuCount(int count)
    {
        tokuCount += count;
        tokuText.text = tokuCount.ToString("F0");
    }
}
