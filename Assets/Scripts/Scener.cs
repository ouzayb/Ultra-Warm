using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Scener : MonoBehaviour
{
    float teleportTime = 0.3f, fadeTime = 0.3f;
    public GameObject Fader;
    float nextTeleport;
    public int id;
    bool teleport = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    if(teleport == true && nextTeleport < Time.timeSinceLevelLoad)
        {
            SceneManager.LoadScene(id);
            teleport = false;
            Fader.GetComponent<Image>().DOFade(0, fadeTime);
        }
    }
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
            teleport = true;
            nextTeleport = teleportTime + Time.timeSinceLevelLoad;
            Fader.GetComponent<Image>().DOFade(1, fadeTime);
        }
	}
}
