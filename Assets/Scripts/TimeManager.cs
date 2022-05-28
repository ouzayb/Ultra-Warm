using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float timeMultiplier;
    [SerializeField] private const float stopTime = 1.5f;
    [SerializeField] private float stopTimer;
    [SerializeField] private float waitTime = 1.5f;
    [SerializeField] bool stop = false;
    [SerializeField] bool inProgress = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (NoButtonsPressed() && !inProgress && !stop)
        {
            inProgress = true;
            StartCoroutine(Timer(true));
        }
        else if(!NoButtonsPressed() && !inProgress && stop)
        {
            inProgress = true;
            StartCoroutine(Timer(false));

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

    IEnumerator Timer(bool stopper)
    {
        if (stopper)
        {
            stopTimer = stopTime;
            while (stopTimer > 0)
            {
                timeMultiplier = func1(stopTimer);
                Time.timeScale = timeMultiplier;
                stopTimer -= waitTime;
                yield return new WaitForSecondsRealtime(waitTime);
            }
            Time.timeScale = 0;
            inProgress = false;
            stop = true;

        }
        else
        {
            stopTimer = 0;
            while (stopTimer < stopTime)
            {
                timeMultiplier = func1(stopTimer);
                Time.timeScale = timeMultiplier;
                stopTimer += waitTime;
                yield return new WaitForSecondsRealtime(waitTime);
            }
            Time.timeScale = 1;
            inProgress = false;
            stop = false;
        }
    }
        
    

    float func1(float inp) 
    {
        float firstVal = Mathf.Pow(stopTime, 2f);
        return Mathf.Pow(inp, 2f)/firstVal;  // to satart the values from 1
    }

    float func2(float inp)
    {
        float firstVal = stopTime;
        return inp / firstVal;  // to satart the values from 1
    }
    float func3(float inp)
    {
        float firstVal = Mathf.Sin(stopTime * Mathf.PI/(2f* stopTime));
        return Mathf.Sin(inp * Mathf.PI / (2f * stopTime)) / firstVal;
    }
}
