using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float timeMultiplier;
    [SerializeField] private float stopTime = 1.5f;
    [SerializeField] bool stop = false;
    [SerializeField] bool inProgress = false;
    // Start is called before the first frame update

    [SerializeField] private AnimationCurve stopCurve = AnimationCurve.Linear(0, 0, 1, 1);
    void Start()
    {
        Time.timeScale = 0;
        stop = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(NoButtonsPressed());
        if (NoButtonsPressed() && !inProgress && !stop)
        {
            inProgress = true;
            StartCoroutine(Timer(stopTime, true));
        }
        else if(!NoButtonsPressed() && !inProgress && stop)
        {
            inProgress = true;
            StartCoroutine(Timer(stopTime, false));

        }
    }

    bool NoButtonsPressed()
    {
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical") || Input.GetButton("Fire")) //if any key is pressed(this code is sad bcus I'm baad)
        {
            return false;
        }
        return true;
    }

    IEnumerator Timer(float duration, bool inverse)
    {
        var t = 0f;

        while(t < duration)
        {
            t += Time.unscaledDeltaTime;
            var ratio = t / duration;

            Time.timeScale = Mathf.Lerp(0, 1, stopCurve.Evaluate(inverse ? 1 - ratio : ratio));
            yield return null;
        }
        inProgress = false;
        stop = inverse;
    }
}
