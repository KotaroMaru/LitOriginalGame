using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
[CreateAssetMenu(fileName = "Mission", menuName = "CreateMissionDB")]

public class MissionItem : ScriptableObject
{
    public int missionNum;
    public string missionDescription;
    public string villegerComent;
    public GameObject goalObject;

    public MissionItem(MissionItem missionItem)
    {
        this.missionNum = missionItem.missionNum;
        this.missionDescription = missionItem.missionDescription;
        this.goalObject = missionItem.goalObject;
        this.villegerComent = missionItem.villegerComent;
    }
}