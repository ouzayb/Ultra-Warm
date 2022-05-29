using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class katanara : MonoBehaviour
{

    public EnemyManager enem;
    public GameObject katana;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!enem.enemyAlive)
        {
            Instantiate(katana, transform);
            Destroy(gameObject,0.2f);
        }
    }
}
