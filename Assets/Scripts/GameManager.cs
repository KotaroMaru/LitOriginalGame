using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
public class GameManager : MonoBehaviour
{
    private bool isGameStop = false;
    //結果UI
    [SerializeField] private Canvas gameOverCanvas;
    [SerializeField] private Canvas gameClearCanvas;
    [SerializeField] private Text clearResultText;
    [SerializeField] private Text failedTokuText;
    [SerializeField] private Text clearTokuText;

    //タイマー
    [SerializeField] private Text timerText;
    private float timeCount = 0;
    [SerializeField] private float timeLimit;

    //徳テキスト
    [SerializeField] private Text tokuText;
    public static int tokuCount;
    private int todayTokuCount;
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
        tokuText.text = tokuCount.ToString("f0"); ;
        todayTokuCount = 0;
    }
    void Update()
    {
        if (isGameStop) return;
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
            isGameStop = true;
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
        AddTokuCount(-100);
        failedTokuText.text = "徳ポイント:" + tokuCount.ToString("F0") + "(" + todayTokuCount.ToString("F0") + ")";

    }
    public void GameClear()
    {
        Time.timeScale = 0f;
        gameClearCanvas.gameObject.SetActive(true);
        clearResultText.text = "残り時間：" + timeCount.ToString("f0") + "秒";
        AddTokuCount((int)timeCount / 2);
        clearTokuText.text = "徳ポイント:" + tokuCount.ToString("F0") + "(+" + todayTokuCount.ToString("F0") + ")";
    }
    public void MissionClear()
    {
        AddTokuCount(10);
    }
    public void MissionFailed()
    {
        AddTokuCount(-5);
    }
    private void AddTokuCount(int count)
    {
        todayTokuCount += count;
        tokuCount += count;
        tokuText.text = tokuCount.ToString("F0");
    }
}
