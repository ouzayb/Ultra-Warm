using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    public Camera cam;
    public Transform obj;
    float dist => transform.position.z - obj.position.z; 
    Vector2 startPosition;
    Vector2 travel => (Vector2) cam.transform.position - startPosition;
    float clippingPlane => (cam.transform.position.z + (dist > 0 ? cam.farClipPlane : cam.nearClipPlane));
    float startZ;
    float paralax => Mathf.Abs(dist) / clippingPlane;
    void Start()
    {
        startPosition = transform.position;
        startZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newpos = startPosition + travel*paralax;
        transform.position = new Vector3(newpos.x, newpos.y, startZ); 
    }
}
