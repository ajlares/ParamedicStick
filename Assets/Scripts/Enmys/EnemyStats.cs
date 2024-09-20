using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private int damage;
    [SerializeField] private float StopDistace;
    [SerializeField] private bool isMele;
    [SerializeField] private bool isDeath;

    public void TakeDamage(int damage)
    {
        life -= damage;
        if(life < 0)
        {
            life = 0;
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
}
