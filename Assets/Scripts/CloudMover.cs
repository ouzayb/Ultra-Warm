using UnityEngine;

public class CloudMover : MonoBehaviour
{
    public Rigidbody2D clouds;

    public float backgroundSpeed; // Moves the background objects with given value. DEFAULT = 0.5f

    void Start()
    {
        clouds.velocity = new Vector2(backgroundSpeed, 0);
    }
}
