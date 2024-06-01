using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaikaiTargetController : MonoBehaviour
{
    public int thisTargetPosNum;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Villager")
        {
            other.gameObject.GetComponent<VillagerController>().SetHaikaiPos(thisTargetPosNum);
        }
    }
}
