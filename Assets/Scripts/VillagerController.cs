using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VillagerController : MonoBehaviour
{
    public MissionManager missionManager;
    private Animator myAnimator;

    public GameObject targetObject;
    NavMeshAgent myNavMeshAgent;
    void Start()
    {
        myAnimator = this.gameObject.GetComponent<Animator>();
        myNavMeshAgent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if (myNavMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            // NavMeshAgentに目的地をセット
            myNavMeshAgent.SetDestination(targetObject.transform.position);
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
        if (other.gameObject.tag == "Player")
        {
            missionManager.OtodokeStart();
        }
    }
}
