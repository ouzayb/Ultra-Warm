using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private int healthPoints;
    [SerializeField] private int damage;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerController>(out var player))
        {
            throw new NotImplementedException();
        }
    }
}
