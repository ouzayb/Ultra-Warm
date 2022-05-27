using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target; // Target to follow
    public float cameraSpeed; // Speed of Camera/Smoothness
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        this.transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), cameraSpeed);
    }
}
