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
        // inicia la corrutina de spawn
        StartCoroutine(SpawnSystem());
    }

    // corrutina de spawn
    IEnumerator SpawnSystem()
    {
        Spawn();
        yield return new WaitForSeconds(SpawnTime);
        StartCoroutine(SpawnSystem());
        yield return null;
    }
    
    // sistema de spawn
    private void Spawn()
    {
        // genera numero random para selecionar el spawn 
        int rSpawn = Random.Range(0, spawners.Count);
        // por un numero random genera o un enfermo o un enemigo
        if(0 == Random.Range(0,2))
        {
            // genera un numero para el enemigo
            int rEnemy = Random.Range(0,enemys.Count);
            // lo espawnea
            Instantiate(enemys[rEnemy],spawners[rSpawn].transform);
        }
        else
        {
            // spawnea un enfermo
            Instantiate(sicks,spawners[rSpawn].transform);
        }
    }
}
