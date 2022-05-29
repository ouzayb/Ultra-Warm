using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HurtTextManager : MonoBehaviour
{
    public GameObject damageTextPrefab, textParent;

    // Update is called once per frame
    void Update()
    {
    }

    public void CreateText(int damage)
    {
        GameObject DamageText = Instantiate(damageTextPrefab, new Vector3(transform.position.x - 0.27f, transform.position.y + 0.16f, transform.position.z) ,new Quaternion(0,0,0,0),textParent.transform);
        DamageText.GetComponent<TextMesh>().text= damage.ToString() + " seconds lost";
    }
}
