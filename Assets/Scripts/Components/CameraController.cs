using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] public Transform target;
    [SerializeField] public Vector3 offset;
    [SerializeField] private Vector3 velocity = Vector3.zero;
    [SerializeField] private float smoothSpeed = 0.125f;

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
    }
}
