using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private int damage;
    [SerializeField] private float StopDistace;
    [SerializeField] private int rangeMaxDistance;
    [SerializeField] private float attackColdown;
    [SerializeField] private bool isMele;
    [SerializeField] private bool isDeath;
    [SerializeField] private bool canShoot;

    public int Life
    {
        get
        {
            return life;
        }
        set
        {
            life -= value;
            if(life<1)
            {
            isDeath = true;
            }
        }
    }
    public int Damage
    {
        get
        {
            return damage;
        }
    }

    public bool IsDeath
    {
        get 
        {
            return isDeath;
        }
    }
    public bool IsMele
    {
        get
        {
            return isMele;
        }
    }

    public float StopDistance
    {
        get 
        {
            return StopDistace;
        }
    }

    public bool CanShoot
    {
        get 
        {
            return canShoot;
        }
        set
        {
            canShoot = value;
        }
    }

    public float AttackColdown
    {
        get
        {
            return attackColdown;
        }
    }

    public int RangeMaxDistance
    {
        get
        {
            return rangeMaxDistance;
        }
    }
}
