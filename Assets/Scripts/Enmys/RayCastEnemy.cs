using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastEnemy : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private bool isPlayer;
    
    public void CreateRay(GameObject target, int MaxDistance)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, target.transform.position - transform.position);    

        if(Physics.Raycast(ray, out hit, MaxDistance, layerMask))
        {
            if(hit.transform.gameObject.CompareTag("Player"))
            {
                Debug.DrawRay(transform.position ,target.transform.position - transform.position, Color.red);
                isPlayer = true;
            }
            else
            {
                Debug.DrawRay(transform.position ,target.transform.position - transform.position, Color.white);
                isPlayer = false;
            }
        }
    }

    public bool IsPlayer
    {
        get
        {
            return isPlayer;
        }
    }

}
