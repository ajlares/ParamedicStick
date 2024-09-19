using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private int damage;

    public void TakeDamage(int damage)
    {
        life -= damage;
        if(life < 0)
        {
            life = 0;
        }
    }
}
