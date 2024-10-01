using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform projectileSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    public void Shoot(int damage)
    {
            PlayerStats.instance.IsAttacking = true;

            var knife = Instantiate(bulletPrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            knife.GetComponent<Projectile>().Damage = damage;
            knife.GetComponent<Rigidbody>().velocity = projectileSpawnPoint.forward * bulletSpeed;
        StartCoroutine(AttackUpdate());
    }
    private IEnumerator AttackUpdate()
    {
        yield return new WaitForSeconds(5.25f);
        
        Debug.Log("Reset Animation");
        PlayerStats.instance.AnimationInteger(0);
        yield return new WaitForSeconds(0.1f);
        PlayerStats.instance.IsAttacking = false;
    }
}
