using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
    [SerializeField] public int requiredTokuCount;
    private BoxCollider myCollider;
    private MeshRenderer myMesh;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = this.gameObject.GetComponent<BoxCollider>();
        myMesh = this.gameObject.GetComponent<MeshRenderer>();
        myCollider.enabled = true;
        myMesh.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.tokuCount >= requiredTokuCount)
        {
            myCollider.enabled = false;
            myMesh.enabled = false;
        }
    }
}
