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
    [SerializeField] private List<GameObject> sicks;
    // variables de control
    [SerializeField] private float SpawnTime;


    private void Start()
    {
        StartCoroutine(SpawnSystem());
    }

    IEnumerator SpawnSystem()
    {
        yield return null;
    }

    private void Spawn()
    {
        
    }
}
