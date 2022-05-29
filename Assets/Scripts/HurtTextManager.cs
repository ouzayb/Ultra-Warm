using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HurtTextManager : MonoBehaviour
{
    public GameObject damageTextPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("k")) CreateText(5);
    }

    public void CreateText(int damage)
    {
        Debug.Log("bbob");
        GameObject DamageText = Instantiate(damageTextPrefab, transform);
        DamageText.GetComponent<TextMeshPro>().text= "- hhhhhhhhhhhh" /*+ damage.ToString() + " seconds lost"*/;
    }
}
