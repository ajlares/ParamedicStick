using UnityEngine;

public class MeleAplyDamage : MonoBehaviour
{
    [SerializeField] private int damage;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        if(other.GetComponent<GameObject>().CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().Life = Damage;
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
}
