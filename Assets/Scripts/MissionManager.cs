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
    private GameObject targetVilleger;
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
        targetVilleger = null;
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
                MissionEnd(false);
            }
        }


    }

    //お届けミッション//
    public void OtodokeStart(GameObject villeger)
    {
        if (isMission) return;
        targetVilleger = villeger;
        isMission = true;
        Debug.Log("OtodokeMissionStart");
        missionCanvas.gameObject.SetActive(true);
        missionText.text = "レストランへ向かえ";
        missionGoal.SetActive(true);
        missionTimeCount = missionMaxTime;
        missionSlider.value = missionTimeCount / missionMaxTime;
    }

    public void MissionClear()
    {
        MissionEnd(true);
        targetVilleger.GetComponent<VillagerController>().MissionEnd();
        Debug.Log("MISSIONCLEAR");
    }
    public void MissionEnd(bool isSuccess)
    {
        if (isSuccess == true)
        {
            missionText.text = "人助け成功！";
        }
        else
        {
            missionText.text = "失敗";
        }
        missionSlider.gameObject.SetActive(false);
        StartCoroutine("destroyUI");


    }

    IEnumerator destroyUI()
    {
        yield return new WaitForSeconds(2.5f);
        isMission = false;
        missionCanvas.gameObject.SetActive(false);
        missionTimeCount = 0;
        missionGoal.SetActive(false);
    }
}
