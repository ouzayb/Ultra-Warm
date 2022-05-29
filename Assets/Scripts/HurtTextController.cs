using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HurtTextController : MonoBehaviour
{
    TextMesh thisText;
    public Color color_i, color_f;
    public Vector3 initialOffset, finalOffset; //position to drift to, relative to the gameObject's local origin
    public float fadeDuration;
    private float fadeStartTime;
    // Start is called before the first frame update
    void Start()
    {
        thisText = GetComponent<TextMesh>();
        fadeStartTime = Time.time;
        initialOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("asd bitch");
        float progress = (Time.time - fadeStartTime) / fadeDuration;
        if (progress <= 1)
        {
            //lerp factor is from 0 to 1, so we use (FadeExitTime-Time.time)/fadeDuration
            transform.position = Vector3.Lerp(initialOffset, initialOffset + finalOffset, progress);
        }
        else Destroy(gameObject);
    }
}
