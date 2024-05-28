using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public Vector3 cameraTransPos;
    public GameObject player;
    private float cameraSpeed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position + cameraTransPos, Time.deltaTime * cameraSpeed);

        this.transform.position = player.transform.position + cameraTransPos;
    }
}
