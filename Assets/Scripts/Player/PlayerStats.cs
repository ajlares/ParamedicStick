using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private  float maxLife;
    [SerializeField] private float life;
    [SerializeField] private bool isDeath;
    [SerializeField] private int damage;

    public static PlayerStats instance;
    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy( this);
        }
        life = maxLife;    
    }

    public float Life
    {
        get
        {
            return life;
        }
        set
        {
            life -= value;
            UIManager.instance.UpdateUI();
            if(life<1)
            {
                IsDeath = true;
            }
        }
    }
    public float MaxLife
    {
        get
        {
            return maxLife;
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
