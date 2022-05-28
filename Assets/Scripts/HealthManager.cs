using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    [SerializeField] private int playerMaxHealth;
    [SerializeField] private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getDamaged(int damage)
    {
        currentHealth = currentHealth < damage ? 0 : currentHealth - damage;
        Debug.Log("Penaltied");
    }
    public int getHealth()
    {
        Debug.Log("Penaltied");
        return currentHealth;
    }

}
