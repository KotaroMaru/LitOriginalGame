using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MissionDB", menuName = "CreateMissionDB")]
public class MissionDatabase : ScriptableObject
{
    public List<MissionItem> items = new List<MissionItem>();
}

