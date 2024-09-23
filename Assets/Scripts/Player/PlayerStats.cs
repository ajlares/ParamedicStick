using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int life;

    public int Life
    {
        get
        {
            return life;
        }
        set
        {
            life -= value;
            // esto puede que nos sirva para la muerte :p
            if(life<1)
            {
            //isDeath = true;
            }
            Debug.Log("Vida actual del jugador: " + life);
        }
    }

}
