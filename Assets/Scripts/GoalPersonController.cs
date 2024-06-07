using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPersonController : MonoBehaviour
{
    private MissionManager missionManager;
    [SerializeField] private VillagerController villagerController;
    // Start is called before the first frame update
    void Start()
    {
        missionManager = GameObject.FindWithTag("GameController").GetComponent<MissionManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            missionManager.MissionClear();
            villagerController.MissionEnd();
        }
    }
}
