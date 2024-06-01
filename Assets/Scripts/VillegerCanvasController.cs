using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillegerCanvasController : MonoBehaviour
{
    [SerializeField]
    private Transform _camera = null;

    private void Update()
    {
        transform.LookAt(_camera);
    }
}
