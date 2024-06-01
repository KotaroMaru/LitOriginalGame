using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour
{
    //General
    public Canvas missionCanvas;
    public Text missionText;
    public Slider missionSlider;
    public float missionMaxTime;
    //ミッションの残り時間
    private float missionTimeCount;
    private bool isMission = false;
    //お届けミッション
    public GameObject missionGoal;


    void Start()
    {
        //初期設定
        //general
        missionCanvas.gameObject.SetActive(false);
        missionText.text = "";
        missionTimeCount = 0;
        isMission = false;
        //お届けミッション
        missionGoal.SetActive(false);
    }
    void Update()
    {
        if (isMission == true)
        {
            missionTimeCount -= Time.deltaTime;
            missionSlider.value = missionTimeCount / missionMaxTime;
            if (missionTimeCount <= 0)
            {
                Debug.Log("MissionFailed");
                MissionEnd();
            }
        }


    }

    //お届けミッション//
    public void OtodokeStart()
    {
        if (isMission) return;
        isMission = true;
        Debug.Log("OtodokeMissionStart");
        missionCanvas.gameObject.SetActive(true);
        missionText.text = "交番へ向かえ";
        missionGoal.SetActive(true);
        missionTimeCount = missionMaxTime;
        missionSlider.value = missionTimeCount / missionMaxTime;
    }

    public void MissionClear()
    {
        MissionEnd();
        Debug.Log("MISSIONCLEAR");
    }
    public void MissionEnd()
    {
        isMission = false;
        missionCanvas.gameObject.SetActive(false);
        missionTimeCount = 0;
        missionGoal.SetActive(false);

    }
}
