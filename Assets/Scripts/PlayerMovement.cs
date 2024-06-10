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
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float moveForce;
    [SerializeField] private float maxSpeed;
    [SerializeField] private GameManager gameManager;

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
            myRigid.AddForce(transform.forward * moveForce * Time.deltaTime * 100);
        }
        if (Input.GetKey(KeyCode.DownArrow) && myRigid.velocity.magnitude < maxSpeed)
        {
            myRigid.AddForce(-transform.forward * moveForce * Time.deltaTime * 100);
        }
    }
    private void HandleRotation()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime * 10, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -rotateSpeed * Time.deltaTime * 10, 0);
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

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Barrier")
        {
            gameManager.ShowNeedTokuPointUI(other.gameObject.GetComponent<BarrierController>().requiredTokuCount);
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Barrier")
        {
            gameManager.HideNeedTokuPointUI();
        }
    }
}
