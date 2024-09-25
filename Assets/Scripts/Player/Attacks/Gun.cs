using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform projectileSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    public void Shoot(int damage)
    {
            var knife = Instantiate(bulletPrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            knife.GetComponent<Projectile>().Damage = damage;
            knife.GetComponent<Rigidbody>().velocity = projectileSpawnPoint.forward * bulletSpeed;
    }
}
