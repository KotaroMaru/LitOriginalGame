using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillegerCanvasController : MonoBehaviour
{

    private Transform _camera = null;

    private void Start()
    {
        _camera = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
    }
    private void Update()
    {
        transform.LookAt(_camera);
    }
}
