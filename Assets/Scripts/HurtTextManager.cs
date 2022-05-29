using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HurtTextManager : MonoBehaviour
{
    public GameObject damageTextPrefab, enemyInstance;
    public string textToDisplay;
    // Update is called once per frame
    void Update()
    {
    }

    public void CreateText(int damage)
    {
        GameObject DamageText = Instantiate(damageTextPrefab, enemyInstance.transform);
        DamageText.GetComponent<TextMeshPro>().SetText(textToDisplay);
    }
}
