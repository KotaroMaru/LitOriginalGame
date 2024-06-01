using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class VillagerController : MonoBehaviour
{
    public MissionManager missionManager;
    private Animator myAnimator;
    private bool isMissioned = false;
    public GameObject targetObject;
    public bool isChase;
    public Text myText;
    private Vector3 targetHaikaiPos;
    public GameObject[] HaikaiPosObj;
    NavMeshAgent myNavMeshAgent;

    void Start()
    {
        isMissioned = false;
        myAnimator = this.gameObject.GetComponent<Animator>();
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        isChase = false;

    }


    void Update()
    {
        if (isMissioned == true) return;
        if (myNavMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid && isChase == true)
        {
            // NavMeshAgentに目的地をセット
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
            missionManager.OtodokeStart(this.gameObject);
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
