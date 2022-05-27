using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    public Rigidbody2D objectRB;

    public int backgroundSpeed; 

    void Start()
    {
        objectRB.velocity = new Vector2(backgroundSpeed, 0); // Moves background object with given value. DEFAULT = 0.5f
    }

    void Update()
    {

    }
}
