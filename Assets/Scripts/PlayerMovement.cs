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
    private float rotateSpeed = 1.0f;
    public float moveSpeed = 250.0f;
    public float maxSpeed = 30.0f;

    void Start()
    {
        myAnimator = this.gameObject.GetComponent<Animator>();
        myRigid = this.gameObject.GetComponent<Rigidbody>();
        myAnimator.SetBool("Move", false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, rotateSpeed, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -1 * rotateSpeed, 0);

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (myRigid.velocity.magnitude < maxSpeed)
            {
                myRigid.AddForce(transform.forward * moveSpeed);
            }
            myAnimator.SetBool("Move", true);


        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (myRigid.velocity.magnitude < maxSpeed)
            {
                myRigid.AddForce(-1 * transform.forward * moveSpeed);
            }
            myAnimator.SetBool("Move", true);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            myAnimator.SetBool("Move", false);

        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            myAnimator.SetBool("Move", false);

        }
    }
}
