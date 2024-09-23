using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform projectileSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            var knife = Instantiate(bulletPrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            knife.GetComponent<Rigidbody>().velocity = projectileSpawnPoint.forward * bulletSpeed;
        }
    }
}
