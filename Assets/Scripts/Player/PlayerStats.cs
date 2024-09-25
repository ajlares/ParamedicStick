using UnityEngine;

public class PlayerStats : MonoBehaviour
{
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
