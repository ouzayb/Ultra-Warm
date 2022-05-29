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
    }

    public void CreateText(int damage)
    {
        GameObject DamageText = Instantiate(damageTextPrefab, transform);
        DamageText.GetComponent<TextMeshPro>().SetText("-" + damage.ToString() + " seconds lost");
    }
}
