using UnityEngine;

public class BulletStats : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float speed;

    private void Start() 
    {
        Destroy(gameObject, 15f);
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

    public float Speed
    {
        get 
        {
            return speed;
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().Life = damage;
            Destroy(gameObject);
        }    
        else if(other.gameObject.CompareTag("Map"))
        {
            Destroy(gameObject);
        }
    }
}
