using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookInCamera : MonoBehaviour
{
    [SerializeField] Camera cam;
    void FixedUpdate()
    {
        transform.LookAt(cam.transform);
    }
}
