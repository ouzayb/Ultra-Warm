using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public Transform Player;
    public Transform Cam;
    public Transform TeleportGround;
    public GameObject Fader;
    float teleportTime = 0.3f, fadeTime = 0.3f;
    float nextTeleport;
    public Vector3 characterDifferenceToCam;
    bool teleport = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    if(teleport == true && nextTeleport < Time.timeSinceLevelLoad)
        {
            Player.position = TeleportGround.position + characterDifferenceToCam;
            Cam.position = TeleportGround.position;
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
