using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class VillagerController : MonoBehaviour
{
    private MissionManager missionManager;
    private Animator myAnimator;
    private bool isMissioned = false;
    [SerializeField] private GameObject targetObject;
    public bool isChase;
    [SerializeField] private Text myText;
    [SerializeField] private Vector3 targetHaikaiPos;
    [SerializeField] private GameObject[] HaikaiPosObj;
    NavMeshAgent myNavMeshAgent;
    [SerializeField] private MissionItem myMission;
    [SerializeField] private GameObject missionObject;

    void Start()
    {
        missionManager = GameObject.FindWithTag("GameController").GetComponent<MissionManager>();
        isMissioned = false;
        myAnimator = this.gameObject.GetComponent<Animator>();
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        isChase = false;
        if (missionObject != null)
        {
            myMission.targetObj = missionObject;
        }
        myText.text = myMission.villegerComent;
    }


    void Update()
    {
        if (isMissioned == true) return;
        if (myNavMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid && isChase == true)
        {
            // NavMeshAgentに目的地をセット
            if (targetObject == null) return;
            myNavMeshAgent.SetDestination(targetObject.transform.position);
        }
        else
        {
            myNavMeshAgent.SetDestination(targetHaikaiPos);

        }


        if (myNavMeshAgent.velocity != Vector3.zero)
        {
            myAnimator.SetBool("Move", true);
        }
        else
        {
            myAnimator.SetBool("Move", false);

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (isMissioned == true) return;
        if (other.gameObject.tag == "Player")
        {
            missionManager.MissionStart(this.gameObject, myMission);
        }
    }
    public void MissionEnd()
    {
        isMissioned = true;
        myText.text = "ありがとう！";
        myNavMeshAgent.velocity = Vector3.zero;
        myNavMeshAgent.SetDestination(transform.position);
        myAnimator.SetBool("Move", false);
    }

    public void SetHaikaiPos(int now)
    {
        if (isChase) return;
        List<int> numbers = new List<int>();
        for (int i = 0; i < HaikaiPosObj.Length; i++)
        {
            numbers.Add(i);
        }

        numbers.RemoveAt(now);
        int r = Random.Range(0, numbers.Count);
        targetHaikaiPos = HaikaiPosObj[numbers[r]].transform.position;

    }

}
