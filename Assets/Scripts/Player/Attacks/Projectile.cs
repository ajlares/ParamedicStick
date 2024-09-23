using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Puede que este codigo no haga falta despues
    [SerializeField] private float lifeTime = 3;

    private void Awake()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Map")){
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyStats>().Life = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().Damage;
            Destroy(gameObject) ;
        }
        
    }
}
