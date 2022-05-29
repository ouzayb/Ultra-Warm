using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HurtTextController : MonoBehaviour
{
    TextMeshProUGUI thisText;
    public Color color_i, color_f;
    public Vector3 initialOffset, finalOffset; //position to drift to, relative to the gameObject's local origin
    public float fadeDuration;
    private float fadeStartTime;
    // Start is called before the first frame update
    void Start()
    {
        thisText = GetComponent<TextMeshProUGUI>();
        fadeStartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("asd bitch");
        float progress = (Time.time - fadeStartTime) / fadeDuration;
        if (progress <= 1)
        {
            //lerp factor is from 0 to 1, so we use (FadeExitTime-Time.time)/fadeDuration
            transform.localPosition = Vector3.Lerp(initialOffset, finalOffset, progress);
            thisText.color = Color.Lerp(color_i, color_f, progress);
        }
        else Destroy(gameObject);
    }
}
