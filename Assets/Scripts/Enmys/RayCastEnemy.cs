using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastEnemy : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private bool isPlayer;
    public void CreateRay(GameObject target)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, target.transform.position - transform.position);    
        Debug.DrawRay(ray.origin,ray.direction*30f, Color.green);

        if(Physics.Raycast(ray, out hit, playerLayer))
        {
            Debug.Log(hit.transform.gameObject.tag);
            hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            if(hit.transform.gameObject.CompareTag("Player"))
            {
                isPlayer = true;
            }
            else
            {
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
