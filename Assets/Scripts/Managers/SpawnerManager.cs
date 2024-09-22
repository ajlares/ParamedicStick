using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    // lista de spawners
    [SerializeField] private List<GameObject> spawners;
    // lista de enemigos
    [SerializeField] private List<GameObject> enemys;
    // lista de enfermos
    [SerializeField] private GameObject sicks;
    // variables de control
    [SerializeField] private float SpawnTime;


    private void Start()
    {
        StartCoroutine(SpawnSystem());
    }

    IEnumerator SpawnSystem()
    {
        Spawn();
        yield return new WaitForSeconds(SpawnTime);
        StartCoroutine(SpawnSystem());
        yield return null;
    }

    private void Spawn()
    {
        int rSpawn = Random.Range(0, spawners.Count);
        int rEnemy = Random.Range(0,enemys.Count);
        if(0 == Random.Range(0,2))
        {

            Debug.Log("0, sale un enemigo");
            Instantiate(enemys[rEnemy],spawners[rSpawn].transform);
        }
        else
        {
            Debug.Log("1, sale un enfermos");
            Instantiate(sicks,spawners[rSpawn].transform);
        }
    }
}
