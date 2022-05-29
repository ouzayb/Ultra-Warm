using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CanvasOpener : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<Image>().DOFade(0, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
	}
}
