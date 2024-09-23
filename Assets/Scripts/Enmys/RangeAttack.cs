using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;

    public void Shoot(int damage, GameObject target)
    {
    GameObject balaTemp = Instantiate(bullet, spawnPoint.transform.position, transform.rotation);
    balaTemp.GetComponent<BulletStats>().Damage  = damage;
    Rigidbody rb = balaTemp.GetComponent<Rigidbody>();
    rb.AddForce((target.transform.position - spawnPoint.transform.position) * bulletSpeed);
    
    }

}
