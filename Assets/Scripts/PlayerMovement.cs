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
        InitializeComponents();
        InitilizeSettings();

    }
    private void InitializeComponents()
    {
        myAnimator = this.gameObject.GetComponent<Animator>();
        myRigid = this.gameObject.GetComponent<Rigidbody>();
    }
    private void InitilizeSettings()
    {
        myAnimator.SetBool("Move", false);

    }

    // Update is called once per frame
    void Update()
    {
        HandleRotation();
        HandleMovement();
        HandleMovementAnimation();
    }
    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow) && myRigid.velocity.magnitude < maxSpeed)
        {
            myRigid.AddForce(transform.forward * moveSpeed);
        }
        if (Input.GetKey(KeyCode.DownArrow) && myRigid.velocity.magnitude < maxSpeed)
        {
            myRigid.AddForce(-transform.forward * moveSpeed);
        }
    }
    private void HandleRotation()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, rotateSpeed, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -rotateSpeed, 0);
        }
    }
    private void HandleMovementAnimation()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            myAnimator.SetBool("Move", true);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            myAnimator.SetBool("Move", false);
        }
    }
}
