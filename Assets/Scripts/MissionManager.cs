using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour
{
    //General
    [SerializeField] private Canvas missionCanvas;
    [SerializeField] private Text missionText;
    [SerializeField] private Slider missionSlider;
    [SerializeField] private float missionMaxTime;
    private GameObject targetVilleger;
    [SerializeField] private GameManager gameManager;

    //ミッションの残り時間
    private float missionTimeCount;
    private bool isMission = false;
    private bool isEndDuration = false;
    //お届けミッション
    private GameObject mygoalObj;
    //拾いミッション
    [SerializeField] private GameObject tomatoObject;
    //人探しミッション
    [SerializeField] private GameObject goalPersonPrefab;

    private GameObject goalPerson;

    private GameObject missionObj;
    private int missionNum;
    void Start()
    {
        //初期設定
        InitializeMission();
    }
    void Update()
    {
        if (isMission == true && isEndDuration == false)
        {
            UpdateMissionTime();
        }
    }
    private void UpdateMissionTime()
    {
        missionTimeCount -= Time.deltaTime;
        missionSlider.value = missionTimeCount / missionMaxTime;
        if (missionTimeCount <= 0)
        {
            Debug.Log("MissionFailed");
            MissionEnd(false);
        }
    }
    private void InitializeMission()
    {
        //general
        missionCanvas.gameObject.SetActive(false);
        missionText.text = "";
        missionTimeCount = 0;
        isMission = false;
        targetVilleger = null;

    }

    //ミッション//
    public void MissionStart(GameObject villeger, MissionItem mission)
    {
        if (isMission) return;
        missionCanvas.gameObject.SetActive(true);
        targetVilleger = villeger;
        isMission = true;
        this.missionNum = mission.missionNum;
        missionText.text = mission.missionDescription;
        missionTimeCount = missionMaxTime;
        missionSlider.gameObject.SetActive(true);
        missionSlider.value = missionTimeCount / missionMaxTime;
        switch (missionNum)
        {
            //お届け
            case 0:
                OtokdokeMissionStart(mission.targetObj);
                break;
            case 1:
                HiroiMissionStart(mission.targetObj.transform);
                break;
            case 2:
                HitosagashiMissionStart(mission.targetObj.transform);
                break;
        }
    }
    private void OtokdokeMissionStart(GameObject goalObj)
    {
        mygoalObj = goalObj;
        mygoalObj.SetActive(true);
    }
    private void HiroiMissionStart(Transform goalPos)
    {
        missionObj = Instantiate(tomatoObject, goalPos);
    }
    private void HitosagashiMissionStart(Transform genePos)
    {
        goalPerson = Instantiate(goalPersonPrefab, genePos);
        VillagerController villagerController = goalPerson.GetComponent<VillagerController>();
        villagerController.HaikaiPosObj = targetVilleger.GetComponent<VillagerController>().HaikaiPosObj;
    }

    public void MissionClear()
    {
        MissionEnd(true);
        targetVilleger.GetComponent<VillagerController>().MissionEnd();
        Debug.Log("MISSIONCLEAR");
        gameManager.MissionClear();
    }
    public void MissionEnd(bool isSuccess)
    {
        missionText.text = isSuccess ? "人助け成功！" : "失敗";

        missionSlider.gameObject.SetActive(false);
        if (isSuccess == false)
        {
            gameManager.MissionFailed();
            //終了処理
            if (missionNum == 0)
            {
                mygoalObj.SetActive(false);
            }
            if ((missionNum == 1) && (isSuccess == false))
            {
                Destroy(missionObj);
            }
            if ((missionNum == 2) && (isSuccess == false))
            {
                Destroy(goalPerson);
            }
            //終了処理UI
            isEndDuration = true;
            StartCoroutine(DeactivateMissionUI());

        }

        IEnumerator DeactivateMissionUI()
        {
            yield return new WaitForSeconds(2.5f);
            isMission = false;
            missionCanvas.gameObject.SetActive(false);
            missionTimeCount = 0;
            isEndDuration = false;
        }

    }
}
