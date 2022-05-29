using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private HurtTextManager TextManager;
    [SerializeField] private TextMeshProUGUI clock; 
    [SerializeField] private float playerMaxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private float timeSaved=0;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        decrementHealth();
        show();
    }

    public void getDamaged(float damage)
    {
        //TextManager.CreateText((int)damage);
        currentHealth = currentHealth < damage ? 0 : currentHealth - damage;
    }
    public void getDamagedWOtext(float damage)
    {;
        currentHealth = currentHealth < damage ? 0 : currentHealth - damage;
    }
    public float getHealth()
    {
        return currentHealth;
    }

    void decrementHealth()
    {
       getDamagedWOtext(Time.timeSinceLevelLoad - timeSaved);
       timeSaved = Time.timeSinceLevelLoad;
    }
    void show()
    {
        int minutes = (int)(currentHealth / 60);
        int seconds = (int)(currentHealth % 60);
        clock.text = minutes.ToString() + ":" + seconds.ToString();
    }
}
