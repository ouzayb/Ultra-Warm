using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float pressedButton;
    [SerializeField] private float stopTime;
    [SerializeField] bool stop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (noButtonsPressed())
        {
            Time.timeScale = 0;
            stop = true;
        }
        else
        {
            Time.timeScale = 1;
            stop = false;
        }
        //if((stopTime < Time.timeSinceLevelLoad))
        //Time.timeScale = timeMultiplier;
    }

    bool noButtonsPressed()
    {
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical") || Input.GetButton("Fire")) //if any key is pressed(this code is sad bcus I'm baad)
        {
            return false;
        }
        return true;
    }
}
