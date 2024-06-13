using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using Palmmedia.ReportGenerator.Core.Parser.Analysis;
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
    private static float timeLimit = 120;
    private float initialTimeLimit = 120;

    //徳テキスト
    [SerializeField] private Text tokuText;
    public static int tokuCount;
    private int todayTokuCount;
    [SerializeField] Text needTokuPoint;
    //BGM,SE
    [SerializeField] AudioClip[] audioClips;
    private AudioSource audioSource;
    void Start()
    {
        //bgm

        this.audioSource = GetComponent<AudioSource>();
        audioSource.pitch = 1.0f;

        if (tokuCount >= 150)
        {
            audioSource.PlayOneShot(audioClips[5]);
        }
        else
        {
            audioSource.PlayOneShot(audioClips[0]);

        }
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
        needTokuPoint.enabled = false;

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
        if (timeCount < 30.0f)
        {
            audioSource.pitch = 1.3f;
        }
    }
    public void RetryButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOver()
    {
        audioSource.pitch = 1.0f;

        audioSource.PlayOneShot(audioClips[4]);

        //General
        Time.timeScale = 0f;
        //Canvas
        gameOverCanvas.gameObject.SetActive(true);
        AddTokuCount(-30);
        timeLimit -= 10;
        failedTokuText.text = "徳ポイント:" + tokuCount.ToString("F0") + "(" + todayTokuCount.ToString("F0") + ")";

    }
    public void GameClear()
    {
        audioSource.pitch = 1.0f;

        audioSource.PlayOneShot(audioClips[3]);

        Time.timeScale = 0f;
        gameClearCanvas.gameObject.SetActive(true);
        clearResultText.text = "残り時間：" + timeCount.ToString("f0") + "秒";
        AddTokuCount((int)timeCount / 2);
        clearTokuText.text = "徳ポイント:" + tokuCount.ToString("F0") + "(+" + todayTokuCount.ToString("F0") + ")";
        timeLimit = initialTimeLimit;
    }
    public void MissionClear()
    {
        audioSource.PlayOneShot(audioClips[1]);
        AddTokuCount(10);
    }
    public void MissionFailed()
    {
        audioSource.PlayOneShot(audioClips[2]);

        AddTokuCount(-5);
    }
    private void AddTokuCount(int count)
    {
        todayTokuCount += count;
        tokuCount += count;
        tokuText.text = tokuCount.ToString("F0");
    }
    public void ShowNeedTokuPointUI(int point)
    {
        needTokuPoint.enabled = true;
        needTokuPoint.text = "徳ポイント" + point + "で開放";
    }
    public void HideNeedTokuPointUI()
    {
        needTokuPoint.enabled = false;
    }
}
