using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackManager : MonoBehaviour
{
    public float timeScale = 0.1f;
    public float knocbackTime = 0.75f;
    bool inProgress = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Knock(Transform hitter, Transform target, float strenght, float jump)
    {
        float difference = hitter.position.x - target.position.x;
        if(difference >= 0)
        {
            StartCoroutine(Knocking(target, strenght, jump,true));
            inProgress = true;
        }
        else
        {
            StartCoroutine(Knocking(target, strenght, jump, true));
            inProgress = true;
        }
    }

    IEnumerator Knocking(Transform target, float strenght, float jump,bool left)
    {
            var t = 0f;

            while (t < knocbackTime)
            {
                t += Time.deltaTime;
                var ratio = t / knocbackTime;

                if(left) target.localPosition -= new Vector3(strenght * timeScale, strenght * timeScale / jump, 0);
                else  target.localPosition += new Vector3(strenght * timeScale, strenght * timeScale / jump, 0);
                yield return null;
            }
            inProgress = false;
        }
}
