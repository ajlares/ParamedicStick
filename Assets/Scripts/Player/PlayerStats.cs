using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private bool isDeath;
    [SerializeField] private int damage;

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
                IsDeath = true;
            }
            Debug.Log("Vida actual del jugador: " + life);
        }
    }

    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }

    public bool IsDeath
    {
        get
        {
            return isDeath;
        }
        set
        {
            isDeath = value;
        }
    }

}
