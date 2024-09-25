using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Puede que este codigo no haga falta despues
    [SerializeField] private float lifeTime = 3;
    [SerializeField] private int damage ;
    [SerializeField] private List<AudioSource> sounds;
    private void Awake()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Map"))
        {
            sounds[0].Play();
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            sounds[1].Play();
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
