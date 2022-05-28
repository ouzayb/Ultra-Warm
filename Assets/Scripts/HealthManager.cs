using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

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
        
    }

    public void getDamaged(float damage)
    {
        currentHealth = currentHealth < damage ? 0 : currentHealth - damage;
        Debug.Log("Penaltied");
    }
    public float getHealth()
    {
        return currentHealth;
    }

    void decrementHealth()
    {
       getDamaged(Time.timeSinceLevelLoad - timeSaved);
       timeSaved = Time.timeSinceLevelLoad;
    }

}
