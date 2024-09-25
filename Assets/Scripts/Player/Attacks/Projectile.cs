using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float lifeTime = 10;
    [SerializeField] private int damage ;
    [SerializeField] private List<GameObject> sounds;
    private void Awake()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Map"))
        {
            Instantiate(sounds[0],transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(sounds[1],transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<EnemyStats>().Life = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().Damage;
            Destroy(gameObject) ;
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
