using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
[CreateAssetMenu(fileName = "Mission", menuName = "CreateMission")]

public class MissionItem : ScriptableObject
{
    public int missionNum;
    public string missionDescription;
    public string villegerComent;
    public GameObject targetObj;

    public MissionItem(MissionItem missionItem)
    {
        this.missionNum = missionItem.missionNum;
        this.missionDescription = missionItem.missionDescription;
        this.targetObj = missionItem.targetObj;
        this.villegerComent = missionItem.villegerComent;
    }
}