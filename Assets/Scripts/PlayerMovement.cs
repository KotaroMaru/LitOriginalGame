using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody myRigid;
    private Animator myAnimator;
    private Vector3 movingDirection;
    private float rotateSpeed = 9.0f;
    private float moveSpeed = 200.0f;
    private float maxSpeed = 20.0f;

    void Start()
    {
        myAnimator = this.gameObject.GetComponent<Animator>();
        myRigid = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 moveDir = new Vector3(x, 0, z);
        moveDir.Normalize();
        //回転
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        //移動
        if (myRigid.velocity.magnitude < maxSpeed)
        {
            myRigid.AddForce(moveDir * moveSpeed);
        }
        //アニメーション
        if (moveDir != Vector3.zero)
        {
            myAnimator.SetBool("isMove", true);
        }
        else
        {
            myAnimator.SetBool("isMove", false);
        }
    }
}
